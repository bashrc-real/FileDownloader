using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDownloaderAndSampler.Worker;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileDownloaderAndSampler.Controllers
{
    [Route("api/downloader")]
    public class DownloadTrigger : Controller
    {
        private readonly static INetworkDownloader networkDownloader = new HttpDownloader(new System.Net.WebClient());
        private readonly static DownloadWorker downloadWorker = new DownloadWorker(networkDownloader, 100);

        public class FileId
        {
            public Uri DownloadUri { get; set; }
            public string ResourceId { get; set; }
        }

        // GET api/fileId
        [HttpGet("{id}")]
        public async Task<Model.FileModel> Get(string id)
        {
            return default(Model.FileModel);
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody]List<Uri> valuesToDownload)
        {
            return "";
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
