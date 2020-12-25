using System;
using System.Collections.Generic;
using System.Linq;

namespace NaUrokApiClient
{
    public class TestSession : ICloneable
    {
        public int Id { get; set; }        
        public string UuId { get; set; }        
        public int? SettingsId { get; set; }        
        public int? CreatorId { get; set; }
        public string TestName { get; set; }
        public int TestQuestionsCount { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTime? EndDateTime
        {
            get
            {
                return Duration is null ? (DateTime?)null : StartDateTime.Add((TimeSpan)Duration);
            }
        }
        public DateTime? TestEndDateTime { get; set; }
        public DateTime? TestStartDateTime { get; set; }
        public List<TestQuestion> Questions { get; private set; }

        public TestSession()
        {
            Questions = new List<TestQuestion>();
        }

        public object Clone()
        {
            var session = new TestSession();
            session.Id                  = Id;
            session.UuId                = UuId;
            session.SettingsId          = SettingsId;
            session.CreatorId           = CreatorId;
            session.TestName            = TestName;
            session.TestQuestionsCount  = TestQuestionsCount;
            session.StartDateTime       = StartDateTime;
            session.Duration            = Duration;
            session.TestEndDateTime     = TestEndDateTime;
            session.TestStartDateTime   = TestStartDateTime;
            session.Questions           = Questions.Select(question => (TestQuestion)question.Clone()).ToList();

            return session;
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
