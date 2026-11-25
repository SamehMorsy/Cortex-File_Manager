using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortex.Models
{
    public enum DuplicateAction
    {
        Overwrite,
        Skip,
        Rename
    }

    public class SearchResultItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string DirectoryPath { get; set; }
        public bool IsDirectory { get; set; }
        public long SizeBytes { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class OperationProgressInfo
    {
        public int Percentage { get; set; }
        public string CurrentFileName { get; set; }
        public string StatusMessage { get; set; }
    }
}
