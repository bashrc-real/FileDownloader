using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FileDownloaderAndSampler.Worker
{
    public class DownloadStatusNotifier
    {
        private long totalBytes;
        private long totalBytesDownloaded;

        public delegate void OnDownloadComplete();

        public KeyValuePair<long, long> GetDownloadStatus() { return KeyValuePair.Create(this.totalBytes, this.totalBytesDownloaded); }

        public long TotalBytes 
        {
            set
            {
                this.totalBytes = value;
            }
        }

        public void SetDownloadProgess(long totalBytesDownloaded) { this.totalBytesDownloaded = totalBytesDownloaded; }

        public bool IsDownloadFaulted() { return this.totalBytesDownloaded == -1; }

        public OnDownloadComplete DownloadComplete { get; set; }
    }

    public interface INetworkDownloader
    {
        Task DownloadFile(Uri sourceUri, string fullFilePath, long maxInMemoryBufferSize, DownloadStatusNotifier downloadProgressNotifier);    
    }
}
