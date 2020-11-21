using NaOtvet.Api.Models;
using NaOtvet.WebApi.Models;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace NaOtvet.WebApi.Controllers
{
    [RoutePrefix("api/application/downloads")]
    public class DownloadsController : ApiController
    {
        private static ApplicationDatabaseContext context { get; set; }

        public DownloadsController()
        {
            context = new ApplicationDatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Route("")]
        public int GetTotalDownloadsCount()
        {
            return context.ApplicationVersions
                .Select(version => version.DownloadsCount)
                .Sum();
        }

        [Route("unique")]
        public int GetUniqueDownloadsCount()
        {
            return context.ApplicationVersions
                .Select(version => version.NewUsersDownloadsCount)
                .Sum();
        }

        private int NewDownload(ApplicationVersion version)
        {
            var userIP = HttpContext.Current.Request.UserHostAddress;
            var thisUserDownloads = context.Downloads
                .Where(download => download.IP == userIP);
            
            var newDownload = new Download
            {
                IP = userIP,
                ApplicationVersionId = version.Id,
                DateTime = DateTime.UtcNow,
            };
            context.Downloads.Add(newDownload);

            if (thisUserDownloads.Count() == 0)
                version.NewUsersDownloadsCount++;

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
                var applicationVersion = context.ApplicationVersions
                    .First(appVersion => appVersion.Version == version);

                return NewDownload(applicationVersion);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [Route("~/api/application/lastVersion/newDownload")]
        [HttpPut]
        public int LastVersionNewDownload()
        {
            var appVersionsController = new ApplicationVersionsController();
            var lastVersionId = appVersionsController.GetLastVersion().Id;
            var lastVersion = context.ApplicationVersions.First(version => version.Id == lastVersionId);

            return NewDownload(lastVersion);
        }
    }
}
