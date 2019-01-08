namespace FileDownloaderAndSampler
{
    using System;
    namespace Model
    {
        [Flags]
        public enum FileStatus
        {
            None = 0,
            InQueue = 1,
            Downloading = (1 << 1),
            Downloaded = (1 << 2),
            Approved = Downloaded | (1 << 3),
            Rejected = Downloaded | (1 << 4)
        }
    }
}
