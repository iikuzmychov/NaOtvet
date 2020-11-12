using NaOtvet.Core;
using System;

namespace NaOtvet
{
    public class OnDocumentIsFoundArgs : EventArgs
    {
        public int DocumentId { get; set; }
        public FlashCard[] FlashCards { get; set; }


        public OnDocumentIsFoundArgs(int documentId, FlashCard[] flashCards)
        {
            DocumentId = documentId;
            FlashCards = flashCards;
        }
    }
}
