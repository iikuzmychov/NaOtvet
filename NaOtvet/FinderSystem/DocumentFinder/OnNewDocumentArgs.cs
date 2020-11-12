using System;

namespace NaOtvet
{
    public class OnNewDocumentArgs : EventArgs
    {
        public int DocumentId { get; set; }

        public OnNewDocumentArgs(int documentId)
        {
            DocumentId = documentId;
        }
    }
}
