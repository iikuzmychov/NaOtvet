using NaOtvet.Core;
using NaOtvet.WebApi.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace NaOtvet.WebApi.Controllers
{
    [RoutePrefix("api/application/versions")]
    public class ApplicationVersionsController : ApiController
    {
        private static ApplicationDatabaseContext context { get; set; }

        public ApplicationVersionsController()
        {
            context = new ApplicationDatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Route("~/api/application/version")]
        [HttpPost]
        public ApplicationVersion GetValue([FromBody] string version)
        {
            try
            {
                return context.ApplicationVersions.First(appVersion => appVersion.Version == version);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        private int NewDownload(ApplicationVersion version)
        {
            version.DownloadsCount++;
            context.SaveChanges();

            return version.DownloadsCount;
        }

        [Route("~/api/application/version/newDownload")]
        [HttpPut]
        public int NewDownload([FromBody] string version)
        {
            try
            {
                var applicationVersion = context.ApplicationVersions.First(appVersion => appVersion.Version == version);
                return NewDownload(applicationVersion);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [Route("~/api/application/lastVersion")]
        [HttpGet]
        public ApplicationVersion LastVersion()
        {
            try
            {
                return context.ApplicationVersions
                    .OrderByDescending(appVersion => appVersion.Version)
                    .First();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [Route("~/api/application/lastVersion/newDownload")]
        [HttpPut]
        public int LastVesrsionNewDownload()
        {
            var lastVersion = LastVersion();
            return NewDownload(lastVersion);
        }
    }
}
