using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OperationManager_Sandbox
{
    public class DriveInformation
    {
        public string Name { get; set; } = string.Empty;

        public DriveType Type { get; set; }

        public long TotalSize { get; set; }

        public long AvailableFreeSpace { get; set; }
    }

    public class FileInformation
    {
        public string Name { get; set; } = string.Empty;

        public string FullPath { get; set; } = string.Empty;

        public long Size { get; set; }

        public string Extension { get; set; } = string.Empty;

        public DateTime CreationTime { get; set; }

        public DateTime LastModified { get; set; }
    }

    public class FolderInformation
    {
        public string Name { get; set; } = string.Empty;

        public string FullPath { get; set; } = string.Empty;

        public DateTime CreationTime { get; set; }

        public DateTime LastModified { get; set; }
    }

    public class SystemInformation
    {
        public List<DriveInformation> GetAvailableDrives()
        {
            List<DriveInformation> drives = new();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                try
                {
                    if (!drive.IsReady)
                    {
                        continue;
                    }

                    DriveInformation driveInfo = new DriveInformation
                    {
                        Name = drive.Name,
                        Type = drive.DriveType,
                        TotalSize = drive.TotalSize,
                        AvailableFreeSpace = drive.AvailableFreeSpace
                    };

                    drives.Add(driveInfo);
                }
                catch (IOException)
                {
                    // Skip drives that cannot currently be accessed.
                }
                catch (UnauthorizedAccessException)
                {
                    // Skip drives that require permissions.
                }
            }

            return drives;
        }

        public FileInformation? GetFileInformation(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);

                if (!file.Exists)
                {
                    return null;
                }

                return new FileInformation
                {
                    Name = file.Name,
                    FullPath = file.FullName,
                    Size = file.Length,
                    Extension = file.Extension,
                    CreationTime = file.CreationTime,
                    LastModified = file.LastWriteTime
                };
            }
            catch (Exception ex) when (
                ex is IOException ||
                ex is UnauthorizedAccessException ||
                ex is ArgumentException ||
                ex is NotSupportedException)
            {
                return null;
            }
        }

        public FolderInformation? GetFolderInformation(string folderPath)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(folderPath);

                if (!folder.Exists)
                {
                    return null;
                }

                return new FolderInformation
                {
                    Name = folder.Name,
                    FullPath = folder.FullName,
                    CreationTime = folder.CreationTime,
                    LastModified = folder.LastWriteTime
                };
            }
            catch (Exception ex) when (
                ex is IOException ||
                ex is UnauthorizedAccessException ||
                ex is ArgumentException ||
                ex is NotSupportedException)
            {
                return null;
            }
        }

        public bool OpenPath(string path, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    errorMessage = "The path cannot be empty.";
                    return false;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                };

                Process.Start(startInfo);

                return true;
            }
            catch (Exception ex) when (
                ex is IOException ||
                ex is UnauthorizedAccessException ||
                ex is ArgumentException ||
                ex is InvalidOperationException ||
                ex is System.ComponentModel.Win32Exception ||
                ex is NotSupportedException)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}