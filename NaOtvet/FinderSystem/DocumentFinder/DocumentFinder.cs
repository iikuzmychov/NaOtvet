using NaOtvet.Core;
using System;
using System.Threading.Tasks;

namespace NaOtvet
{
    public class DocumentFinder
    {
        private RequestsSender requestsSender;

        public int StartDocumentId { get; set; }
        public int StartIndex { get; set; }
        public int IterationsCount { get; set; }
        public TestSession TestSession { get; set; }
        public bool IsStopped { get; private set; }
        public int CheckedDocumentsCount { get; private set; } = 0;

        public event EventHandler<OnNewDocumentArgs> OnNewDocument;
        public event EventHandler<OnDocumentIsFoundArgs> OnDocumentIsFound;
        public event EventHandler OnEnd;

        public DocumentFinder(RequestsSender requestsSender, int startDocumentId, int startIndex,
            int iterationsCount, TestSession testSession)
        {
            this.requestsSender = requestsSender;

            StartDocumentId = startDocumentId;
            StartIndex      = startIndex;
            IterationsCount = iterationsCount;
            TestSession     = testSession;
        }

        public void Restart(int startIndex, int iterationsCount)
        {
            StartIndex = startIndex;
            IterationsCount = iterationsCount;

            Task.Run(FindDocument);
        }

        public void Start()
        {
            Restart(StartIndex, IterationsCount);
        }

        public void Stop()
        {
            IsStopped = true;
        }

        private void FindDocument()
        {
            IsStopped = false;

            for (int i = StartIndex; i < StartIndex + IterationsCount && !IsStopped; i++)
            {
                for (int j = 0; j < 2 && !IsStopped; j++)
                {
                    if (IsStopped)
                        break;

                    if (i == 0)
                        j = 1;

                    int documentId = (j % 2 == 0) ? StartDocumentId + i : StartDocumentId - i;
                    var isCorrectDocument = IsCorrectDocument(TestSession, documentId, requestsSender, out FlashCard[] cards);

                    CheckedDocumentsCount++;

                    if (isCorrectDocument)
                    {
                        OnDocumentIsFound.Invoke(this, new OnDocumentIsFoundArgs(documentId, cards));
                        Stop();
                        break;
                    }
                    else
                    {
                        OnNewDocument.Invoke(this, new OnNewDocumentArgs(documentId));
                        continue;
                    }
                }
            }

            IsStopped = true;
            OnEnd.Invoke(this, new EventArgs());
        }

        public static bool IsCorrectDocument(TestSession testSession, int documentId, RequestsSender requestsSender, out FlashCard[] flashCards)
        {
            var response = requestsSender.GetFlashCards(documentId);

            if (response.Content.StartsWith("{\"result\":false") == false)
            {
                flashCards = ResponsesParser.ParseFlashCards(response.Content).ToArray();
                return testSession.IsCorrectFlashCards(flashCards);                
            }
            else
            {
                flashCards = null;
                return false;
            }
        }
    }
}
