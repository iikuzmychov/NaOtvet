using NaOtvet.Api.Models;
using NaOtvet.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace NaOtvet.WebApi.Controllers
{
    [RoutePrefix("api/info/webLinks")]
    public class WebLinksController : ApiController
    {
        private static ApplicationDatabaseContext context { get; set; }

        public WebLinksController()
        {
            context = new ApplicationDatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Route("")]
        public IEnumerable<WebLink> GetValues()
        {
            return context.WebLinks.ToList();
        }

        [Route("")]
        [HttpPost]
        public IEnumerable<WebLink> GetValue([FromBody] string[] names)
        {
            try
            {
                return context.WebLinks.Where(webLink => names.Contains(webLink.Name));
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
