using System.Collections.Generic;

namespace NaUrokApiClient
{
    public class TestDocument
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public List<TestQuestion> Questions { get; private set; }

        public TestDocument()
        {
            Questions = new List<TestQuestion>();
        }
    }
}
