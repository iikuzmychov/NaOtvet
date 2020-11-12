using NaOtvet.Core;
using NaOtvet.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace NaOtvet.WebApi.Controllers
{
    [RoutePrefix("api/tests/solvedSessions")]
    public class SolvedTestsSessionsController : ApiController
    {
        private static ApplicationDatabaseContext context { get; set; }

        public SolvedTestsSessionsController()
        {
            context = new ApplicationDatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Route("fromSettings/{settingsId:int}")]
        public IEnumerable<SolvedTestSession> GetValueFromSettings(int settingsId)
        {
            return context.SolvedTestsSessions.Where(session => session.SettingsId == settingsId);
        }

        [Route("new")]
        [HttpPost]
        public void Add([FromBody]SolvedTestSession session)
        {
            try
            {
                session.PublishDate = DateTime.Now;
                context.SolvedTestsSessions.Add(session);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
    }
}
