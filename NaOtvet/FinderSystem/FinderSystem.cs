using NaOtvet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaOtvet
{
    public class FinderSystem
    {
        private const double magicConstant = 9.55;

        private RequestsSender requestsSender { get; set; } = new RequestsSender();
        private List<DocumentFinder> documentFinders { get; set; } = new List<DocumentFinder>();
        private TestSession testSession { get; set; }
        private AccountLoginData accountData { get; set; }

        public int ThreadsCount { get; private set; }
        public int StartDocumentId { get; private set; }
        public string TestSessionUuId { get; private set; }
        public int FinderIterationsCount { get; private set; }
        public bool IsStoped { get; private set; } = true;
        public bool TestIsFound { get; private set; } = false;

        public int CheckedDocumentsCount
        {
            get
            {
                return documentFinders.Select(finder => finder.CheckedDocumentsCount).Sum();
            }
        }

        public event EventHandler<OnNewDocumentArgs> OnNewDocument;
        public event EventHandler<OnDocumentIsFoundArgs> OnDocumentIsFound;
        public event EventHandler<OnErrorArgs> OnError;

        public FinderSystem(AccountLoginData accountData, string testSessionUuId,
            int threadsCount, int finderIterationsCount)
        {
            this.accountData = accountData;

            ThreadsCount            = threadsCount;
            FinderIterationsCount   = finderIterationsCount;
            TestSessionUuId         = testSessionUuId;

            Task.Run(Authorization).Wait();
        }

        private void Authorization()
        {
            var csrf = ResponsesParser.GetCsrf(requestsSender.GetLoginPage().Result.Content);
            requestsSender.Autorization(accountData.Login, accountData.Password, csrf).Wait();
        }

        private TestSession GetTestSession(string sessionUuId)
        {
            int sessionId = int.Parse(ResponsesParser.GetSessionId(requestsSender.GetTestingPage(sessionUuId).Content));
            return ResponsesParser.ParseTestSession(requestsSender.GetSession(sessionId).Content);
        }

        private int GetStartDocumentId()
        {            
            return (int)(testSession.Questions.OrderBy(question => question.Id).First().Id / magicConstant);
        }


        private void InitializeFinders()
        {
            for (int i = 0; i < ThreadsCount; i++)
            {
                var finder = new DocumentFinder(requestsSender, StartDocumentId, i * FinderIterationsCount, FinderIterationsCount, testSession);
                finder.OnNewDocument += (sender, args) => OnNewDocument?.Invoke(this, args);
                finder.OnEnd += FinderOnEnd;
                finder.OnDocumentIsFound += FinderOnDocumentIsFound;

                documentFinders.Add(finder);
            }
        }

        private void FinderOnEnd(object sender, EventArgs args)
        {
            if (!TestIsFound && !IsStoped)
            {
                var finder = (DocumentFinder)sender;
                finder.Restart(finder.StartIndex + documentFinders.Count * FinderIterationsCount, FinderIterationsCount);
            }
        }

        private void FinderOnDocumentIsFound(object sender, OnDocumentIsFoundArgs args)
        {
            if (IsStoped)
                return;

            IsStoped = true;
            TestIsFound = true;

            Stop();
            testSession.SetAnswers(args.FlashCards.ToArray());
            OnDocumentIsFound?.Invoke(this, args);
        }


        public void Start()
        {
            Restart(TestSessionUuId);
        }

        public void Restart(string testSessionUuId)
        {
            testSession = GetTestSession(testSessionUuId);
            StartDocumentId = GetStartDocumentId();

            if (testSession.Questions.Count != testSession.TestQuestionsCount)
            {
                OnError?.Invoke(this, new OnErrorArgs(new Exception("Тест частично пройден")));
                return;
            }

            InitializeFinders();

            foreach (var finder in documentFinders)
            {
                finder.Start();
            }

            IsStoped = false;

            Task.Run(CheckCreatorProfileTests);
        }

        private async void CheckCreatorProfileTests()
        {
            if (testSession.CreatorId is null)
                return;

            List<string> testsUrls = new List<string>();
            int page = 0;

            while (true)
            {
                page++;
                
                var response = await requestsSender.GetProfileTests((int)testSession.CreatorId, page);
                var testsUrlsOnPage = ResponsesParser.GetProfileTestsUrls(response.Content);
                testsUrls.AddRange(testsUrlsOnPage);

                if (ResponsesParser.IsLastProfileTestsPage(response.Content))
                    break;
            }

            foreach (var testUrl in testsUrls)
            {
                var documentId = int.Parse(
                    string.Join("", 
                        testUrl.Split(new char[] { '-' }).Last()
                        .TakeWhile(symbol => char.IsNumber(symbol))
                        )
                    );

                if (DocumentFinder.IsCorrectDocument(testSession, documentId, requestsSender, out FlashCard[] flashCards))
                {
                    FinderOnDocumentIsFound(this, new OnDocumentIsFoundArgs(documentId, flashCards));
                }
            }
        }

        public void Stop()
        {
            foreach (var finder in documentFinders)
            {
                finder.Stop();
            }

            IsStoped = true;
        }


        public TestSession GetTestSession()
        {
            return testSession;
        }
    }
}
