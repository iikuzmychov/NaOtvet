using System;

namespace NaOtvet.Core
{
    public class SolvedTestSession
    {
        public int Id { get; set; }
        public int SettingsId { get; set; }
        public int TestId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
