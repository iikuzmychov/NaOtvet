using NaUrokApiClient;
using System;

namespace NaOtvet.Core
{
    public class OnTestDocumentIsFoundArgs : EventArgs
    {
        public int DocumentId { get; set; }
        public TestSession TestSession { get; set; }

        public OnTestDocumentIsFoundArgs(int documentId, TestSession testSession)
        {
            if (testSession is null)
                throw new ArgumentNullException(nameof(testSession));

            DocumentId = documentId;
            TestSession = testSession;
        }

        public OnTestDocumentIsFoundArgs(int documentId, TestSession testSession, FlashCard[] flashCards) : this(documentId, testSession)
        {
            if (testSession is null)
                throw new ArgumentNullException(nameof(testSession));

            if (flashCards is null)
                throw new ArgumentNullException(nameof(flashCards));

            if (testSession.IsCorrectFlashCards(flashCards) == false)
                throw new ArgumentException("Incorrect flash-cards", nameof(flashCards));

            TestSession.SetAnswers(flashCards);
        }
    }
}
