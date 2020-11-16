using NaOtvet.Api.Models;
using NaOtvet.WebApi.Models;
using NaUrokApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [Route("~/api/tests/solvedSession/fromSettings/{settingsId:int}")]
        public SolvedTestSession GetValueFromSettings(int settingsId)
        {
            try
            {
                return context.SolvedTestsSessions.First(session => session.SettingsId == settingsId);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        private bool IsCorrectSolvedSession(SolvedTestSession solvedSession)
        {
            if (solvedSession is null)
                return false;

            var naUrokAccount = context.WebSitesAccounts.First(account => account.WebSite == "https://naurok.com.ua");
            var naUrokClient = new NaUrokClient(naUrokAccount.Login, naUrokAccount.Password);
            TestSession testSession;

            try
            {
                testSession = naUrokClient.GetTestSession(solvedSession.Id);
            }
            catch (Exception)
            {
                return false;
            }

            return naUrokClient.IsCorrectTestDocument(testSession, solvedSession.TestDocumentId, out _);
        }

        [Route("new")]
        [HttpPost]
        public void Add([FromBody]SolvedTestSession solvedSession)
        {
            if (IsCorrectSolvedSession(solvedSession) == false)
                throw new HttpResponseException(HttpStatusCode.Forbidden);

            try
            {
                solvedSession.PublishDate = DateTime.Now;
                var sameSessions = context.SolvedTestsSessions
                    .Where(session => session.Id == solvedSession.Id || session.SettingsId == solvedSession.SettingsId);

                if (sameSessions.Count() > 0)
                    context.SolvedTestsSessions.RemoveRange(sameSessions);

                context.SolvedTestsSessions.Add(solvedSession);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
    }
}
