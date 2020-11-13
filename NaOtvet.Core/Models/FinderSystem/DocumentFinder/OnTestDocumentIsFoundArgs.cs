using NaUrokApiClient;
using System;

namespace NaOtvet.Core
{
    public class OnTestDocumentIsFoundArgs : EventArgs
    {
        public int DocumentId { get; set; }
        public FlashCard[] FlashCards { get; set; }
        public TestSession TestSession { get; set; }


        public OnTestDocumentIsFoundArgs(int documentId, FlashCard[] flashCards, TestSession testSession)
        {
            DocumentId  = documentId;
            FlashCards  = flashCards;
            TestSession = testSession;
        }
    }
}
