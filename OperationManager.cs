using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace OperationManager_Sandbox
{
    public class OperationManager
    {
        private readonly Dictionary<Guid, OperationTask> operations = new();
        private readonly Dictionary<Guid, BackgroundWorker> workers = new();
        private readonly LogManager logManager;

        // Protects both dictionaries and operation state changes.
        private readonly Lock lockObject = new();

        public event EventHandler<OperationUpdatedEventArgs>? OperationUpdated;
        public event EventHandler<ProgressUpdatedEventArgs>? ProgressUpdated;

        public OperationManager(LogManager? logManager = null)
        {
            // Use the supplied logger or create one if none was provided.
            this.logManager = logManager ?? new LogManager();
        }

        public Guid SubmitOperation(
            OperationType type,
            string sourcePath,
            string? destinationPath = null,
            bool supportsCancellation = true,
            string? writeContent = null,
            string? searchPattern = null)
        {
            ArgumentNullException.ThrowIfNull(sourcePath);

            Guid operationId = Guid.NewGuid();

            OperationTask operation = new OperationTask
            {
                Id = operationId,
                Type = type,
                SourcePath = sourcePath,
                DestinationPath = destinationPath,
                WriteContent = writeContent,
                SearchPattern = searchPattern,
                Status = OperationStatus.Pending,
                ProgressPercentage = 0,
                SupportsCancellation = supportsCancellation
            };

            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = supportsCancellation
            };

            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            // Register both entries before notifying subscribers or starting the worker.
            lock (lockObject)
            {
                operations.Add(operationId, operation);
                workers.Add(operationId, worker);
            }

            logManager.AddLog("Operation submitted.", operation);

            // Announce Pending before the worker can announce Running.
            OnOperationUpdated(operation);

            // A pending cancellation is preserved by the CancelRequested flag.
            worker.RunWorkerAsync(operation);

            return operationId;
        }

        // Supports cancellation while Pending or Running.
        public bool CancelOperation(Guid operationId)
        {
            OperationTask? operation;

            lock (lockObject)
            {
                if (!operations.TryGetValue(operationId, out operation))
                {
                    return false;
                }

                bool canBeCancelled =
                    operation.Status == OperationStatus.Pending ||
                    operation.Status == OperationStatus.Running;

                if (!operation.SupportsCancellation || !canBeCancelled)
                {
                    return false;
                }

                if (!workers.TryGetValue(operationId, out BackgroundWorker? worker))
                {
                    return false;
                }

                // Preserve the request even if RunWorkerAsync resets the worker flag.
                operation.CancelRequested = true;

                worker.CancelAsync();
            }

            logManager.AddLog("Cancellation requested.", operation);

            return true;
        }

        public List<OperationTask> GetAllOperations()
        {
            lock (lockObject)
            {
                return new List<OperationTask>(operations.Values);
            }
        }

        // Runs on a background thread.
        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker ||
                e.Argument is not OperationTask operation)
            {
                return;
            }

            lock (lockObject)
            {
                // Do not start work if cancellation was requested while Pending.
                if (operation.CancelRequested || worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                operation.Status = OperationStatus.Running;
                operation.StartTime = DateTime.Now;
            }

            logManager.AddLog("Operation started.", operation);

            OnOperationUpdated(operation);

            worker.ReportProgress(0, "Operation started.");

            OperationContext context = new OperationContext(
                operation,
                () => IsCancellationRequested(operation, worker),
                (percentage, message) =>
                    worker.ReportProgress(Math.Clamp(percentage, 0, 100), message));

            try
            {
                e.Result = ExecuteOperation(context);
            }
            catch (OperationCanceledException)
            {
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                e.Result = new OperationResult
                {
                    Success = false,
                    Message = "Operation failed.",
                    ErrorMessage = $"{ex.GetType().Name}: {ex.Message}"
                };
            }
        }

        // Reads cancellation state using the same lock as CancelOperation.
        private bool IsCancellationRequested(
            OperationTask operation,
            BackgroundWorker worker)
        {
            lock (lockObject)
            {
                return operation.CancelRequested || worker.CancellationPending;
            }
        }

        // Runs on the thread that called SubmitOperation (the UI thread in WinForms).
        private void Worker_ProgressChanged(
            object? sender,
            ProgressChangedEventArgs e)
        {
            if (sender is not BackgroundWorker worker)
            {
                return;
            }

            OperationTask? operation = GetOperationByWorker(worker);

            if (operation == null)
            {
                return;
            }

            lock (lockObject)
            {
                operation.ProgressPercentage = e.ProgressPercentage;
            }

            string progressMessage = e.UserState?.ToString() ?? string.Empty;

            logManager.AddLog(
                $"Progress: {e.ProgressPercentage}% - {progressMessage}",
                operation);

            OnProgressUpdated(
                operation.Id,
                new OperationProgress
                {
                    Percentage = e.ProgressPercentage,
                    StatusMessage = progressMessage
                });
        }

        private void Worker_RunWorkerCompleted(
            object? sender,
            RunWorkerCompletedEventArgs e)
        {
            if (sender is not BackgroundWorker worker)
            {
                return;
            }

            OperationTask? operation = GetOperationByWorker(worker);

            if (operation == null)
            {
                worker.Dispose();
                return;
            }

            string logMessage;

            // Update final state and remove the worker before raising events.
            lock (lockObject)
            {
                if (e.Cancelled)
                {
                    operation.Status = OperationStatus.Cancelled;

                    operation.Result = new OperationResult
                    {
                        Success = false,
                        Message = "Operation was cancelled.",
                        ErrorMessage = null
                    };

                    logMessage = "Operation cancelled.";
                }
                else if (e.Error != null)
                {
                    operation.Status = OperationStatus.Failed;

                    operation.Result = new OperationResult
                    {
                        Success = false,
                        Message = "Operation failed.",
                        ErrorMessage = $"{e.Error.GetType().Name}: {e.Error.Message}"
                    };

                    logMessage = $"Operation failed: {operation.Result.ErrorMessage}";
                }
                else
                {
                    operation.Result = e.Result as OperationResult
                        ?? new OperationResult
                        {
                            Success = false,
                            Message = "Operation failed.",
                            ErrorMessage = "No operation result was returned."
                        };

                    operation.Status = operation.Result.Success
                        ? OperationStatus.Completed
                        : OperationStatus.Failed;

                    if (operation.Status == OperationStatus.Completed)
                    {
                        operation.ProgressPercentage = 100;
                        logMessage = "Operation completed successfully.";
                    }
                    else
                    {
                        logMessage = $"Operation failed: {operation.Result.ErrorMessage}";
                    }
                }

                operation.CompletionTime = DateTime.Now;

                workers.Remove(operation.Id);
            }

            worker.Dispose();

            logManager.AddLog(logMessage, operation);

            OnOperationUpdated(operation);
        }

        // Backend members plug their code in here.
        // Fill context.Result.Content or context.Result.FoundPaths as needed.
        private static OperationResult ExecuteOperation(OperationContext context)
        {
            switch (context.Operation.Type)
            {
                case OperationType.CreateFile:
                case OperationType.DeleteFile:
                case OperationType.RenameFile:
                case OperationType.ReadFile:
                case OperationType.WriteFile:
                    // Core Backend Member 1
                    SimulateWork(context);
                    break;

                case OperationType.CreateDirectory:
                case OperationType.DeleteDirectory:
                case OperationType.RenameDirectory:
                    // Core Backend Member 1
                    SimulateWork(context);
                    break;

                case OperationType.CopyFile:
                case OperationType.MoveFile:
                case OperationType.CopyDirectory:
                case OperationType.MoveDirectory:
                    // Core Backend Member 2
                    SimulateWork(context);
                    break;

                case OperationType.SearchFiles:
                    // Core Backend Member 2
                    SimulateWork(context);
                    break;

                default:
                    throw new NotSupportedException(
                        "Unsupported operation type.");
            }

            return context.Result;
        }

        // Temporary simulation for testing the UI before the real backend exists.
        private static void SimulateWork(OperationContext context)
        {
            for (int step = 1; step <= 10; step++)
            {
                context.ThrowIfCancelled();

                Thread.Sleep(300);

                context.ReportProgress(
                    step * 10,
                    $"Processing step {step} of 10...");
            }
        }

        private OperationTask? GetOperationByWorker(BackgroundWorker worker)
        {
            lock (lockObject)
            {
                foreach (KeyValuePair<Guid, BackgroundWorker> item in workers)
                {
                    if (item.Value == worker &&
                        operations.TryGetValue(item.Key, out OperationTask? operation))
                    {
                        return operation;
                    }
                }
            }

            return null;
        }

        private void OnOperationUpdated(OperationTask operation)
        {
            RaiseSafely(
                OperationUpdated,
                new OperationUpdatedEventArgs(operation));
        }

        private void OnProgressUpdated(
            Guid operationId,
            OperationProgress progress)
        {
            RaiseSafely(
                ProgressUpdated,
                new ProgressUpdatedEventArgs(operationId, progress));
        }

        // A failing subscriber must not prevent other subscribers from running.
        private void RaiseSafely<T>(EventHandler<T>? handler, T args)
            where T : EventArgs
        {
            if (handler == null)
            {
                return;
            }

            foreach (Delegate subscriber in handler.GetInvocationList())
            {
                try
                {
                    ((EventHandler<T>)subscriber)(this, args);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Event subscriber failed: {ex.Message}");
                }
            }
        }
    }
}