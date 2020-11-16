using NaUrokApiClient;
using System;
using System.Threading.Tasks;

namespace NaOtvet.Core
{
    public class TestDocumentFinder : IDisposable
    {
        private NaUrokClient client;
        private Task task;

        public readonly int StartId;
        public readonly TestSession TestSession;
        public int StartIndex { get; private set; }
        public int IterationsCount { get; private set; }
        public bool IsStopped { get; private set; } = false;
        public int CheckedDocumentsCount { get; private set; } = 0;

        public event EventHandler<OnNewTestDocumentArgs> OnNewTestDocument;
        public event EventHandler<OnTestDocumentIsFoundArgs> OnTestDocumentIsFound;
        public event EventHandler<OnErrorArgs> OnError;
        public event EventHandler OnEnd;

        public TestDocumentFinder(NaUrokClient client, TestSession testSession, int startId, int startIndex, int iterationsCount)
        {
            if (client is null)
                throw new ArgumentNullException(nameof(client));

            if (testSession is null)
                throw new ArgumentNullException(nameof(testSession));

            this.client = client;

            TestSession     = testSession;
            StartId         = startId;
            StartIndex      = startIndex;
            IterationsCount = iterationsCount;
        }

        public void Dispose()
        {
            task?.Dispose();
        }

        public void Restart(int startIndex, int iterationsCount)
        {
            StartIndex = startIndex;
            IterationsCount = iterationsCount;

            task = Task.Run(FindTestDocument);
        }

        public void Start()
        {
            Restart(StartIndex, IterationsCount);
        }

        public void Stop()
        {
            IsStopped = true;
        }

        private void FindTestDocument()
        {
            IsStopped = false;

            for (int i = StartIndex; i < StartIndex + IterationsCount && !IsStopped; i++)
            {
                for (int j = 0; j < 2 && !IsStopped; j++)
                {
                    if (i == 0)
                        j = 1;

                    int testDocumentId = (j % 2 == 0) ? StartId + i : StartId - i;
                    bool isCorrectTestDocument;
                    FlashCard[] flashCards;

                    try
                    {
                        isCorrectTestDocument = client.IsCorrectTestDocument(TestSession, testDocumentId, out flashCards);
                    }
                    catch (Exception exception)
                    {
                        OnError?.Invoke(this, new OnErrorArgs(exception));
                        break;
                    }

                    CheckedDocumentsCount++;

                    if (isCorrectTestDocument)
                    {
                        OnTestDocumentIsFound.Invoke(this, new OnTestDocumentIsFoundArgs(testDocumentId, flashCards, TestSession));
                        Stop();
                        break;
                    }
                    else
                    {
                        OnNewTestDocument.Invoke(this, new OnNewTestDocumentArgs(testDocumentId));
                        continue;
                    }
                }
            }

            Stop();
            OnEnd.Invoke(this, new EventArgs());
        }
    }
}
