using System;
using System.Collections.Generic;

namespace OperationManager_Sandbox
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }

        public Guid? OperationId { get; set; }

        public OperationType? OperationType { get; set; }

        public string Message { get; set; } = string.Empty;
    }

    public class LogEntryEventArgs : EventArgs
    {
        public LogEntry Entry { get; }

        public LogEntryEventArgs(LogEntry entry)
        {
            Entry = entry ?? throw new ArgumentNullException(nameof(entry));
        }
    }

    public class LogManager
    {
        private readonly List<LogEntry> logs = new();

        // Protects the log list when multiple threads access it.
        private readonly object lockObject = new();

        public event EventHandler<LogEntryEventArgs>? LogAdded;

        public void AddLog(string message, OperationTask? operation = null)
        {
            ArgumentNullException.ThrowIfNull(message);

            LogEntry entry = new LogEntry
            {
                Timestamp = DateTime.Now,
                OperationId = operation?.Id,
                OperationType = operation?.Type,
                Message = message
            };

            lock (lockObject)
            {
                logs.Add(entry);
            }

            // Notify subscribers after releasing the lock.
            LogAdded?.Invoke(this, new LogEntryEventArgs(entry));
        }

        public List<LogEntry> GetAllLogs()
        {
            lock (lockObject)
            {
                // Return a copy so callers cannot modify the internal list.
                return new List<LogEntry>(logs);
            }
        }

        public void ClearLogs()
        {
            lock (lockObject)
            {
                logs.Clear();
            }
        }
    }
}