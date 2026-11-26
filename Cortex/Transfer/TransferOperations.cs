using Cortex.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                            File.Delete(dest);
                            break;
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
    }
}
