using System;
namespace FileDownloaderAndSampler.Worker
{
    public class DownloadConfiguration
    {
        public string DownloadPath { get; set; }
        public int MaxDownloadWorkers { get; set; }
        public int MaxInMemoryBuffer { get; set; }
    }
}
