using System;

namespace NaUrokApiClient
{
    public class QuestionOption : ICloneable
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public TestQuestion Question { get; set; }

        public object Clone()
        {
            var option = new QuestionOption();
            option.Id       = option.Id;
            option.Content  = option.Content;
            option.Question = Question;

            return option;
        }
    }
}
