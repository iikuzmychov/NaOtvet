using System;

namespace NaOtvet.Api.Models
{
    public class SolvedTestSession
    {
        public int Id { get; set; }
        public int SettingsId { get; set; }
        public int TestDocumentId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
