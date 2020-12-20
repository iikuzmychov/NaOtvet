using System;

namespace NaUrokApiClient
{
    public class QuestionOption : ICloneable
    {
        public int Id { get; set; }
        public string HtmlText { get; set; }
        public string ImageUrl { get; set; }
        public TestQuestion Question { get; set; }

        public object Clone()
        {
            var option = new QuestionOption();
            option.Id       = Id;
            option.HtmlText = HtmlText;
            option.ImageUrl = ImageUrl;
            option.Question = Question;

            return option;
        }
    }
}
