using NaOtvet.Api.Client;
using NaOtvet.Api.Models;
using NaUrokApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NaOtvet.Core
{
    public class FinderSystem : IDisposable
    {
        private const double magicConstant = 9.55;
        private NaUrokClient client;
        private List<TestDocumentFinder> testDocumentFinders;
        private TestSession testSession;
        private int startId;
        private Task specialCasesTask;
        private Task saveSessionTask;

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
            testSession             = client.GetTestSession(testSessionUuId);
        }

        public void Dispose()
        {
            if (testDocumentFinders != null)
            {
                foreach (var finder in testDocumentFinders)
                    finder?.Dispose();
            }

            specialCasesTask?.Dispose();
            saveSessionTask?.Dispose();
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
                finder.OnNewTestDocument += Finder_OnNewDocument;
                finder.OnTestDocumentIsFound += Finder_OnTestDocumentIsFound;
                finder.OnError += Finder_OnError;
                finder.OnEnd += Finder_OnEnd;

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

            saveSessionTask = new Task(() => SaveSolvedSession(args.DocumentId));
            saveSessionTask.Start();

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
            IsStoped = false;
            TestIsFound = false;
            CheckedDocumentsCount = 0;
            TestSessionUuId = testSessionUuId;
            testSession = client.GetTestSession(testSessionUuId);
            startId = GetStartTestDocumentId(testSession);

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

            specialCasesTask = new Task(CheckSpecialCases);
            specialCasesTask.Start();
        }

        public void Stop()
        {
            foreach (var finder in testDocumentFinders)
            {
                finder.Stop();
            }

            IsStoped = true;
        }


        private void CheckSpecialCases()
        {
            var specialCasesFunctions = new Func<bool>[]
            {
                CheckSolvedSessions,
                CheckCreatorProfileTests,
                CheckImagesUrls,
                CheckSameQuestions,
            };

            foreach (var function in specialCasesFunctions)
            {
                var goodResult = function.Invoke();

                if (goodResult)
                    break;
            }
        }

        private bool CheckSolvedSessions()
        {
            if (testSession.SettingsId.HasValue == false)
                return false;

            var solvedSession = NaOtvetClient.GetSolvedTestSession(testSession.SettingsId.Value);

            if (solvedSession is null)
                return false;

            if (client.IsCorrectTestDocument(testSession, solvedSession.TestDocumentId, out FlashCard[] flashCards))
            {
                CheckedDocumentsCount++;
                Finder_OnTestDocumentIsFound(this, new OnTestDocumentIsFoundArgs(solvedSession.TestDocumentId, testSession, flashCards));

                return true;
            }

            return false;
        }

        private bool CheckCreatorProfileTests()
        {
            if (testSession.CreatorId is null)
                return false;

            var testsDocumentsId = client.GetProfilePublicTestsDocumentsId((int)testSession.CreatorId);

            foreach (var testDocumentId in testsDocumentsId)
            {
                if (client.IsCorrectTestDocument(testSession, testDocumentId, out FlashCard[] flashCards))
                {
                    CheckedDocumentsCount++;
                    Finder_OnTestDocumentIsFound(this, new OnTestDocumentIsFoundArgs(testDocumentId, testSession, flashCards));

                    return true;
                }
            }

            return false;
        }

        private bool CheckImagesUrls()
        {
            // example: https://naurok-test2.nyc3.digitaloceanspaces.com/uploads/test/733454/541034/242158_1605794491.jpg
            var urlRegex = new Regex(@"^http[s]?://naurok.*/uploads/test/[0-9]*/[0-9]*/[0-9]*_[0-9]*.[A-z]*$");
            var matchedImagesUrls = new List<string>();

            foreach (var question in testSession.Questions)
            {
                if (question.ImageUrl != null && urlRegex.IsMatch(question.ImageUrl))
                    matchedImagesUrls.Add(question.ImageUrl);

                foreach (var option in question.Options)
                {
                    if (option.ImageUrl != null && urlRegex.IsMatch(option.ImageUrl))
                        matchedImagesUrls.Add(option.ImageUrl);
                }
            }

            foreach (var url in matchedImagesUrls)
            {
                var testDocumentId = int.Parse(url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[5]);

                if (client.IsCorrectTestDocument(testSession, testDocumentId, out FlashCard[] flashCards))
                {
                    CheckedDocumentsCount++;
                    Finder_OnTestDocumentIsFound(this, new OnTestDocumentIsFoundArgs(testDocumentId, testSession, flashCards));

                    return true;
                }
            }

            return false;
        }

        private bool CheckSameQuestions()
        {
            foreach (var currentQuestion in testSession.Questions)
            {
                var documents = client.GetTestsDocumentsWithSameQuestions(currentQuestion.HtmlText);
                var documentsWithCurrentDocumentQuestions = documents
                    .Where(document => 
                        document.Questions
                        .Where(question => testSession.Questions.Select(q => q.Id).Contains(question.Id))
                        .Count() > 0
                        );

                if (documentsWithCurrentDocumentQuestions.Count() == 0)
                    continue;

                foreach (var document in documentsWithCurrentDocumentQuestions)
                {
                    if (client.IsCorrectTestDocument(testSession, document.Id, out FlashCard[] flashCards))
                    {
                        CheckedDocumentsCount++;
                        Finder_OnTestDocumentIsFound(this, new OnTestDocumentIsFoundArgs(document.Id, testSession, flashCards));

                        return true;
                    }
                }                
            }

            return false;
        }


        private void SaveSolvedSession(int testDocumentId)
        {
            if (testSession.SettingsId.HasValue == false)
                return;

            var solvedSession = new SolvedTestSession()
            {
                Id              = testSession.Id,
                SettingsId      = testSession.SettingsId.Value,
                TestDocumentId  = testDocumentId
            };

            NaOtvetClient.SaveSolvedTestSession(solvedSession);
        }
    }
}
