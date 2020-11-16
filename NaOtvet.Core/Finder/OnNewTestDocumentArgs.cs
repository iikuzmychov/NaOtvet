using System;

namespace NaOtvet.Core
{
    public class OnNewTestDocumentArgs : EventArgs
    {
        public int DocumentId { get; set; }

        public OnNewTestDocumentArgs(int documentId)
        {
            DocumentId = documentId;
        }
    }
}
