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

        private static int GetStartTestDocumentId(TestSession session)
        {
            var sortedQuestions = session.Questions.OrderBy(question => question.Id);
            int startDocumentId = (int)(sortedQuestions.First().Id / magicConstant);

            return startDocumentId;
        }

        private void InitializeFinders()
        {
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
            TestSessionUuId = testSessionUuId;
            testSession     = client.GetTestSession(testSessionUuId);
            startId         = GetStartTestDocumentId(testSession);

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

            Task.Run(CheckCreatorProfileTests);
        }

        public void Stop()
        {
            foreach (var finder in testDocumentFinders)
            {
                finder.Stop();
            }

            IsStoped = true;
        }


        private void CheckCreatorProfileTests()
        {
            if (testSession.CreatorId is null)
                return;

            var testsDocumentsId = client.GetProfilePublicTestsDocumentsId((int)testSession.CreatorId);

            foreach (var testDocumentId in testsDocumentsId)
            {
                if (TestDocumentFinder.IsCorrectTestDocument(client, testSession, testDocumentId, out FlashCard[] flashCards))
                {
                    CheckedDocumentsCount++;
                    Finder_OnTestDocumentIsFound(this, new OnTestDocumentIsFoundArgs(testDocumentId, flashCards, testSession));
                }
            }
        }
    }
}
