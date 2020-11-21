using NaUrokApiClient;
using System;

namespace NaOtvet.Core
{
    public class OnTestDocumentIsFoundArgs : EventArgs
    {
        public int DocumentId { get; set; }
        public TestQuestion[] Questions { get; set; }

        public OnTestDocumentIsFoundArgs(int documentId, TestQuestion[] questions)
        {
            DocumentId = documentId;
            Questions = questions;
        }

        public OnTestDocumentIsFoundArgs(int documentId, TestSession testSession)
        {
            if (testSession is null)
                throw new ArgumentNullException(nameof(testSession));

            DocumentId = documentId;
            Questions = testSession.Questions.ToArray();
        }

        public OnTestDocumentIsFoundArgs(int documentId, TestSession testSession, FlashCard[] flashCards)
        {
            if (testSession is null)
                throw new ArgumentNullException(nameof(testSession));

            if (flashCards is null)
                throw new ArgumentNullException(nameof(flashCards));

            if (testSession.IsCorrectFlashCards(flashCards) == false)
                throw new ArgumentException("Incorrect flash-cards", nameof(flashCards));

            testSession.SetAnswers(flashCards);

            DocumentId = documentId;
            Questions = testSession.Questions.ToArray();
        }
    }
}
