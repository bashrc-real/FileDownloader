using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileDownloaderAndSampler.Worker
{
    public class HttpDownloader : INetworkDownloader
    {
        private readonly WebClient webClient;

        // TODO: Should this be a configurable value controlled by the client?
        private readonly int maxAttempts = 5;
        public HttpDownloader(WebClient webClient)
        {
            this.webClient = webClient;
        }

        public async Task DownloadFile(Uri sourceUri, string fullFilePath, long maxInMemoryBufferSize, DownloadStatusNotifier downloadProgressNotifier)
        {
            Func<Task> func = async () =>
            {
                var tsk = this.webClient.DownloadFileTaskAsync(sourceUri.AbsoluteUri, fullFilePath);
                bool firstTime = true;
                this.webClient.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                {
                    if (firstTime)
                    {
                        downloadProgressNotifier.TotalBytes = e.TotalBytesToReceive;
                        firstTime = false;
                    }

                    downloadProgressNotifier.SetDownloadProgess(e.BytesReceived);
                };

                await tsk.ConfigureAwait(false);
            };

            int attempt = 0;
            do
            {
                try
                {
                    await func().ConfigureAwait(false);
                }
                catch (WebException ex)
                {
                    downloadProgressNotifier.SetDownloadProgess(-1);

                }
            } while (++attempt < maxAttempts);
        }
    }
}
