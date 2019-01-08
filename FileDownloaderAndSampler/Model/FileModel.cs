using System;

namespace FileDownloaderAndSampler
{
    namespace Model
    {
        public class FileModel
        {
            public Uri FileUri { get; set; }
            public string FileName { get; set; }
            public FileStatus Status { get; set; } = FileStatus.None;
        }
    }
}
