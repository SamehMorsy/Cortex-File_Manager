using Cortex.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cortex.Transfere
{
    public static class TransferOperations
    {
        public static bool CopyFile(string source, string dest, DuplicateAction action, out string error)
        {
            error = "";
            if (string.IsNullOrEmpty(source) || !File.Exists(source))
            {
                error = "Source file does not exist.";
                return false;
            }

           
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                if (File.Exists(dest))
                {
                    switch (action)
                    {
                        case DuplicateAction.Skip:
                            error = "skipped";
                            return false;
                        case DuplicateAction.Overwrite:
                            break;
                            
                        case DuplicateAction.Rename:
                            dest = GetUniqueFileName(dest);
                            break;

                    }
                }
                File.Copy(source, dest, action == DuplicateAction.Overwrite);
                return true;
            }
            catch (IOException ex )
            {
                error = ex.Message;
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                error = ex.Message;
                return false;
            }
            
        }
        private static string GetUniqueFileName(string path)
        { 
            string folder = Path.GetDirectoryName(path);
            string filename = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            int counter = 1;

            string uniquePath = Path.Combine(folder, $"{filename}{extension}");

            while (File.Exists(uniquePath))
            {
                uniquePath = Path.Combine(folder, $"{filename} ({counter}){extension}");
                counter++;
            }

            return uniquePath;
        }
        public static bool MoveFile(string source, string dest, DuplicateAction action, out string error)
        {
            error = "";
            if (string.IsNullOrEmpty(source) || !File.Exists(source))
            {
                error = "Source file does not exist.";
                return false;
            }

            try
            {
                if (Path.GetFullPath(source).Equals(Path.GetFullPath(dest), StringComparison.OrdinalIgnoreCase))
                {
                    error = "Source and destination paths are the same.";
                    return false;
                }
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                if (File.Exists(dest))
                {
                    switch (action)
                    {
                        case DuplicateAction.Skip:
                            error = "skipped";
                            return false;
                        case DuplicateAction.Overwrite:
                            string tempPath = Path.GetFullPath(dest) + ".tmp";
                            try
                            {
                                File.Move(source, tempPath);
                                File.Delete(dest);
                                File.Move(tempPath, dest);
                                return true;
                            }
                            catch (IOException ex)
                            {
                                error = ex.Message;
                                return false;
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                error = ex.Message;
                                return false;

                            }
                            

                        case DuplicateAction.Rename:
                            dest = GetUniqueFileName(dest);
                            break;
                    }
                }
                File.Move(source, dest);
                return true;
            }
            catch (IOException ex)
            {
                error = ex.Message;
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                error = ex.Message;
                return false;
            }
        }
        public static bool CopyFolder(string sourceDir, string destDir, DuplicateAction action, out string error)
        {
            error = "";
            if (string.IsNullOrEmpty(sourceDir) || !Directory.Exists(sourceDir))
            {
                error = "Source directory does not exist.";
                return false;
            }

            string src = Path.GetFullPath(sourceDir).TrimEnd('\\');
            string dst = Path.GetFullPath(destDir).TrimEnd('\\');
            if (dst.Equals(src, StringComparison.OrdinalIgnoreCase) ||
                dst.StartsWith(src + "\\", StringComparison.OrdinalIgnoreCase))
            {
                error = "Cannot copy a folder into itself.";
                return false;
            }

            var errors = new List<string>();
            try
            {
                Directory.CreateDirectory(destDir);

                foreach (string file in Directory.GetFiles(sourceDir))
                {
                    string destFile = Path.Combine(destDir, Path.GetFileName(file));
                    if (!CopyFile(file, destFile, action, out string fileError) && fileError != "skipped")
                        errors.Add(fileError);
                }

                foreach (string dir in Directory.GetDirectories(sourceDir))
                {
                    string destSub = Path.Combine(destDir, Path.GetFileName(dir));
                    if (!CopyFolder(dir, destSub, action, out string subError) && !string.IsNullOrEmpty(subError))
                        errors.Add(subError);
                }
            }
            catch (IOException ex) { errors.Add(ex.Message); }
            catch (UnauthorizedAccessException ex) { errors.Add(ex.Message); }

            error = string.Join("; ", errors);
            return errors.Count == 0;
        }

    }
}
