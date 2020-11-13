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

    public class TestQuestion
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
