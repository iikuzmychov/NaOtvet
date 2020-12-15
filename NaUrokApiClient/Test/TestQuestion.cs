using System;
using System.Collections.Generic;
using System.Linq;

namespace NaUrokApiClient
{
    public enum QuestionType
    { 
        Unknown,
        OneAnswer,
        ManyAnswers
    }

    public class TestQuestion : ICloneable
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string HtmlText { get; set; }
        public string ImageUrl { get; set; }
        public QuestionType Type { get; set; }
        public List<QuestionOption> Options { get; set; }
        public List<QuestionOption> Answers { get; set; }

        public TestQuestion()
        {
            Options = new List<QuestionOption>();
            Answers = new List<QuestionOption>();
        }

        public object Clone()
        {
            var question = new TestQuestion();
            question.Id         = Id;
            question.Points     = Points;
            question.HtmlText   = HtmlText;
            question.Type       = Type;
            question.Options    = Options.Select(option => (QuestionOption)option.Clone()).ToList();
            question.Answers    = Answers.Select(answer => (QuestionOption)answer.Clone()).ToList();

            foreach (var option in Options)
                option.Question = this;

            foreach (var answer in Answers)
                answer.Question = this;

            return question;
        }

        public bool IsCorrectFlashCard(FlashCard card)
        {
            if (card.QuestionHtmlText != HtmlText)
                return false;

            var answers = card.AnswerHtmlText
                .Split(new string[] { "<div>", "</div>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var answer in answers)
            {
                if (Options
                    .Where(option =>
                    {
                        if (option.HtmlText != string.Empty)
                            return option.HtmlText == answer;
                        else
                            return option.ImageUrl == card.AnswerImageUrl;
                    })
                    .Count() != 1)
                {
                    return false;
                }
            }

            return true;
        }

        public void SetAnswer(FlashCard card, bool isCheckNeeded)
        {
            if (isCheckNeeded)
                if (IsCorrectFlashCard(card) == false)
                    throw new ArgumentException();

            var answers = card.AnswerHtmlText
                .Split(new string[] { "<div>", "</div>" }, StringSplitOptions.RemoveEmptyEntries);

            Answers = Options
                .Where(option =>
                {
                    if (option.HtmlText != string.Empty)
                        return answers.Contains(option.HtmlText);
                    else
                        return option.ImageUrl == card.AnswerImageUrl;
                })
                .ToList();
        }
    }
}
