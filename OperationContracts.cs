using System;
using System.Collections.Generic;

namespace OperationManager_Sandbox
{
    public enum OperationType
    {
        CreateFile,
        DeleteFile,
        RenameFile,
        CreateDirectory,
        DeleteDirectory,
        RenameDirectory,
        ReadFile,
        WriteFile,
        CopyFile,
        MoveFile,
        CopyDirectory,
        MoveDirectory,
        SearchFiles
    }

    public enum OperationStatus
    {
        Pending,
        Running,
        Completed,
        Failed,
        Cancelled
    }

    public class OperationResult
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }

        // Output of ReadFile.
        public string? Content { get; set; }

        // Output of SearchFiles: full paths of the matches.
        public List<string> FoundPaths { get; set; } = new();
    }

    public class OperationProgress
    {
        public int Percentage { get; set; }

        public string StatusMessage { get; set; } = string.Empty;
    }

    public class OperationTask
    {
        public Guid Id { get; set; }

        public OperationType Type { get; set; }

        public string SourcePath { get; set; } = string.Empty;

        public string? DestinationPath { get; set; }

        // Input for WriteFile: the text to write.
        public string? WriteContent { get; set; }

        // Input for SearchFiles: for example "*.txt".
        public string? SearchPattern { get; set; }

        public OperationStatus Status { get; set; }

        public int ProgressPercentage { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? CompletionTime { get; set; }

        public OperationResult Result { get; set; } = new();

        public bool SupportsCancellation { get; set; }

        // Preserves cancellation requests made before the worker starts.
        public bool CancelRequested { get; set; }
    }

    // Gives backend code access to cancellation, progress, and the operation result.
    public class OperationContext
    {
        private readonly Func<bool> isCancelled;
        private readonly Action<int, string> reportProgress;

        public OperationTask Operation { get; }

        public OperationResult Result { get; } = new OperationResult
        {
            Success = true,
            Message = "Operation completed successfully."
        };

        public OperationContext(
            OperationTask operation,
            Func<bool> isCancelled,
            Action<int, string> reportProgress)
        {
            Operation = operation
                ?? throw new ArgumentNullException(nameof(operation));

            this.isCancelled = isCancelled
                ?? throw new ArgumentNullException(nameof(isCancelled));

            this.reportProgress = reportProgress
                ?? throw new ArgumentNullException(nameof(reportProgress));
        }

        public bool IsCancelled => isCancelled();

        public void ReportProgress(int percentage, string message)
        {
            reportProgress(percentage, message);
        }

        // Call before the point of no return (before deleting, overwriting, etc.).
        public void ThrowIfCancelled()
        {
            if (isCancelled())
            {
                throw new OperationCanceledException();
            }
        }
    }

    public class OperationUpdatedEventArgs : EventArgs
    {
        public OperationTask Operation { get; }

        public OperationUpdatedEventArgs(OperationTask operation)
        {
            Operation = operation
                ?? throw new ArgumentNullException(nameof(operation));
        }
    }

    public class ProgressUpdatedEventArgs : EventArgs
    {
        public Guid OperationId { get; }

        public OperationProgress Progress { get; }

        public ProgressUpdatedEventArgs(
            Guid operationId,
            OperationProgress progress)
        {
            OperationId = operationId;

            Progress = progress
                ?? throw new ArgumentNullException(nameof(progress));
        }
    }
}