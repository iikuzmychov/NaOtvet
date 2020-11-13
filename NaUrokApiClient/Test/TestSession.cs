using System;
using System.Collections.Generic;
using System.Linq;

namespace NaUrokApiClient
{
    public class TestSession
    {
        public int Id { get; set; }        
        public int? SettingsId { get; set; }        
        public int? CreatorId { get; set; }
        public string TestName { get; set; }
        public int TestQuestionsCount { get; set; }
        public List<TestQuestion> Questions { get; private set; }

        public TestSession()
        {
            Questions = new List<TestQuestion>();
        }

        public bool IsCorrectFlashCards(FlashCard[] cards)
        {
            if (cards is null || cards.Length != Questions.Count)
                return false;

            var sortedQuestions = Questions.OrderBy(question => question.Id).ToArray();
            var sortedCards = cards.OrderBy(card => card.Id).ToArray();

            for (int i = 0; i < Questions.Count; i++)
            {
                if (sortedQuestions[i].IsCorrectFlashCard(sortedCards[i]) == false)
                    return false;
            }

            return true;
        }

        public void SetAnswers(FlashCard[] cards)
        {
            if (IsCorrectFlashCards(cards) == false)
                throw new ArgumentException();

            var sortedQuestions = Questions.OrderBy(question => question.Id).ToArray();
            var sortedCards = cards.OrderBy(card => card.Id).ToArray();

            for (int i = 0; i < Questions.Count; i++)
            {
                sortedQuestions[i].SetAnswer(sortedCards[i], false);
            }
        }
    }
}
