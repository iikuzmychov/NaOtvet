using NaOtvet.Api.Client;
using NaOtvet.Api.Models;
using NaUrokApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaOtvet.Core
{
    public class FinderSystem
    {
        private const double magicConstant = 9.55;
        private NaUrokClient client;
        private List<TestDocumentFinder> testDocumentFinders;
        private TestSession testSession;
        private int startId;

        public int ThreadsCount { get; private set; }        
        public string TestSessionUuId { get; private set; }
        public int FinderIterationsCount { get; private set; }
        public bool IsStoped { get; private set; } = true;
        public bool TestIsFound { get; private set; } = false;

        public int CheckedDocumentsCount { get; private set; }

        public event EventHandler<OnNewTestDocumentArgs> OnNewDocument;
        public event EventHandler<OnTestDocumentIsFoundArgs> OnDocumentIsFound;
        public event EventHandler<OnErrorArgs> OnError;

        public FinderSystem(NaUrokClient client, string testSessionUuId, int threadsCount, int finderIterationsCount)
        {
            if (client is null)
                throw new ArgumentNullException(nameof(client));

            testDocumentFinders = new List<TestDocumentFinder>();
            this.client = client;

            ThreadsCount            = threadsCount;
            FinderIterationsCount   = finderIterationsCount;
            TestSessionUuId         = testSessionUuId;
        }

        public TestSession GetTestSession()
        {
            return (TestSession)testSession?.Clone();
        }


        private static int GetStartTestDocumentId(TestSession session)
        {
            var sortedQuestions = session.Questions.OrderBy(question => question.Id);
            int startDocumentId = (int)(sortedQuestions.First().Id / magicConstant);

            return startDocumentId;
        }

        private void InitializeFinders()
        {
            foreach (var finder in testDocumentFinders)
            {
                finder.Dispose();

            }

            testDocumentFinders.Clear();

            for (int i = 0; i < ThreadsCount; i++)
            {
                int startIndex = i * FinderIterationsCount;
                var finder = new TestDocumentFinder(client, testSession, startId, startIndex, FinderIterationsCount);
                finder.OnNewTestDocument        += Finder_OnNewDocument;
                finder.OnTestDocumentIsFound    += Finder_OnTestDocumentIsFound;
                finder.OnError                  += Finder_OnError;
                finder.OnEnd                    += Finder_OnEnd;

                testDocumentFinders.Add(finder);
            }
        }


        private void Finder_OnNewDocument(object sender, OnNewTestDocumentArgs args)
        {
            CheckedDocumentsCount++;
            OnNewDocument?.Invoke(this, args);            
        }

        private void Finder_OnTestDocumentIsFound(object sender, OnTestDocumentIsFoundArgs args)
        {
            if (IsStoped)
                return;

            IsStoped = true;
            TestIsFound = true;

            Stop();
            testSession.SetAnswers(args.FlashCards.ToArray());
            Task.Run(() => SaveAnswers(testSession, args.DocumentId));

            OnDocumentIsFound?.Invoke(this, args);
        }

        private void Finder_OnError(object sender, OnErrorArgs args)
        {
            OnError?.Invoke(this, args);
        }

        private void Finder_OnEnd(object sender, EventArgs args)
        {
            if (!TestIsFound && !IsStoped)
            {
                var finder = (TestDocumentFinder)sender;
                finder.Restart(finder.StartIndex + testDocumentFinders.Count * FinderIterationsCount, FinderIterationsCount);
            }
        }


        public void Start()
        {
            Restart(TestSessionUuId);
        }

        public void Restart(string testSessionUuId)
        {
            IsStoped                = false;
            TestIsFound             = false;
            CheckedDocumentsCount   = 0;
            TestSessionUuId         = testSessionUuId;
            testSession             = client.GetTestSession(testSessionUuId);
            startId                 = GetStartTestDocumentId(testSession);

            if (testSession.Questions.Count != testSession.TestQuestionsCount)
            {
                throw new AnsweredQuestionException();
            }

            InitializeFinders();

            foreach (var finder in testDocumentFinders)
            {
                finder.Start();
            }

            IsStoped = false;

            Task.Run(() => CheckCreatorProfileTests(testSession));
            Task.Run(() => CheckSolvedSessions(testSession));
        }

        public void Stop()
        {
            foreach (var finder in testDocumentFinders)
            {
                finder.Stop();
            }

            IsStoped = true;
        }


        private void CheckCreatorProfileTests(TestSession session)
        {
            if (session.CreatorId is null)
                return;

            var testsDocumentsId = client.GetProfilePublicTestsDocumentsId((int)session.CreatorId);

            foreach (var testDocumentId in testsDocumentsId)
            {
                if (client.IsCorrectTestDocument(session, testDocumentId, out FlashCard[] flashCards))
                {
                    CheckedDocumentsCount++;
                    Finder_OnTestDocumentIsFound(this, new OnTestDocumentIsFoundArgs(testDocumentId, flashCards, session));
                }
            }
        }

        private void CheckSolvedSessions(TestSession session)
        {
            if (session.SettingsId.HasValue == false)
                return;

            var solvedSession = NaOtvetClient.GetSolvedTestSession(session.SettingsId.Value);

            if (solvedSession is null)
                return;

            if (client.IsCorrectTestDocument(testSession, solvedSession.TestDocumentId, out FlashCard[] flashCards))
            {
                CheckedDocumentsCount++;
                Finder_OnTestDocumentIsFound(this, new OnTestDocumentIsFoundArgs(solvedSession.TestDocumentId, flashCards, testSession));
            }
        }

        private void SaveAnswers(TestSession session, int testDocumentId)
        {
            if (session.SettingsId.HasValue == false)
                return;

            var solvedSession = new SolvedTestSession()
            {
                Id              = session.Id,
                SettingsId      = session.SettingsId.Value,
                TestDocumentId  = testDocumentId
            };

            NaOtvetClient.SaveSolvedTestSession(solvedSession);
        }
    }
}
