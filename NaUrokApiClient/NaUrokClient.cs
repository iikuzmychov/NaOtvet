using System;
using System.Collections.Generic;
using System.Linq;

namespace NaUrokApiClient
{
    public class NaUrokClient
    {
        private RequestsSender requestsSender;

        public NaUrokClient(string login, string password)
        {
            requestsSender = new RequestsSender();
            Authorization(login, password);
        }

        private void Authorization(string login, string password)
        {
            var loginPageContent = requestsSender.GetLoginPage().Content;
            var csrf = ResponsesParser.ParseCsrf(loginPageContent);

            requestsSender.Autorization(login, password, csrf);
        }


        public int GetTestSessionId(string sessionUuId)
        {
            var testingPageContent = requestsSender.GetTestingPage(sessionUuId).Content;
            int sessionId = ResponsesParser.GetSessionId(testingPageContent);

            return sessionId;
        }

        public TestSession GetTestSession(string sessionUuId)
        {
            int sessionId   = GetTestSessionId(sessionUuId);
            var sessionJson = requestsSender.GetSession(sessionId).Content;
            var session     = ResponsesParser.ParseTestSession(sessionJson);

            return session;
        }

        public FlashCard[] GetFlashCards(int documentId)
        {
            var flashCardsContent = requestsSender.GetFlashCards(documentId).Content;
            var flashCards = ResponsesParser.ParseFlashCards(flashCardsContent);

            return flashCards;
        }

        private int[] GetProfilePublicTestsDocumentsId(int profileId, int page, out string pageContent)
        {
            pageContent     = requestsSender.GetProfileTestsDocuments(profileId, page).Content;
            var testsUrls   = ResponsesParser.GetProfileTestsDocumentsUrls(pageContent);
            var testsId     = new List<int>();

            foreach (var testUrl in testsUrls)
            {
                var testId = int.Parse(
                    string.Join("",
                        testUrl.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                        .Last()
                        .TakeWhile(symbol => char.IsNumber(symbol))
                        )
                    );

                testsId.Add(testId);
            }

            return testsId.ToArray();
        }

        public int[] GetProfilePublicTestsDocumentsId(int profileId)
        {
            var testsId = new List<int>();
            int currentPage = 1;

            while (true)
            {
                var currentPageTestsId = GetProfilePublicTestsDocumentsId(profileId, currentPage, out string pageContent);
                testsId.AddRange(currentPageTestsId);

                if (ResponsesParser.IsLastProfilePage(pageContent))
                    break;
                else
                    currentPage++;
            }

            return testsId.ToArray();
        }
    }
}
