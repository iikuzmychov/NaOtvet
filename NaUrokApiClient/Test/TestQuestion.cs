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
        public string Content { get; set; }
        public QuestionType Type { get; set; }
        public List<QuestionOption> Options { get; private set; }
        public List<QuestionOption> Answers { get; private set; }

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
            question.Content    = Content;
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
            if (card.QuestionContent is null || card.QuestionContent != Content)
                return false;

            var answers = card.AnswerContent
                .Split(new string[] { "<div>", "</div>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var answer in answers)
            {
                if (Options.Where(option => option.Content == answer).Count() != 1)
                    return false;
            }

            return true;
        }

        public void SetAnswer(FlashCard card, bool isCheckNeeded)
        {
            if (isCheckNeeded)
                if (IsCorrectFlashCard(card) == false)
                    throw new ArgumentException();

            var answers = card.AnswerContent
                .Split(new string[] { "<div>", "</div>" }, StringSplitOptions.RemoveEmptyEntries);

            Answers = Options.Where(option => answers.Contains(option.Content)).ToList();
        }
    }
}
