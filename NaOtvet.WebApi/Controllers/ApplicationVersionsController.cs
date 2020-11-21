using NaOtvet.Api.Models;
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
        public ApplicationVersion GetVersion([FromBody] string version)
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

        [Route("~/api/application/lastVersion")]
        [HttpGet]
        public ApplicationVersion GetLastVersion()
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
    }
}
