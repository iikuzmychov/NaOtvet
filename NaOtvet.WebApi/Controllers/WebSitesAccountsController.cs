using NaOtvet.Api.Models;
using NaOtvet.WebApi.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace NaOtvet.WebApi.Controllers
{
    [RoutePrefix("api/info/webSitesAccounts")]
    public class WebSitesAccountsController : ApiController
    {
        private static ApplicationDatabaseContext context { get; set; }

        public WebSitesAccountsController()
        {
            context = new ApplicationDatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Route("~/api/info/webSiteAccount")]
        [HttpPost]
        public WebSiteAccount GetValue([FromBody] string webSite)
        {
            try
            {
                return context.WebSitesAccounts.First(account => account.WebSite == webSite);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
