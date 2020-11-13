using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NaUrokApiClient
{
    static class ResponsesParser
    {
        private static QuestionOption ParseQuestionOption(JToken json)
        {
            var option = new QuestionOption();

            option.Id = json["id"].Value<int>();
            option.Content = json["value"].ToString();

            return option;
        }

        private static TestQuestion ParseTestQuestion(JToken json)
        {
            var question = new TestQuestion();

            question.Id       = json["id"].Value<int>();
            question.Content  = json["content"].ToString();
            question.Points   = json["point"].Value<int>();

            switch (json["type"].ToString())
            {
                case "quiz":
                    question.Type = QuestionType.OneAnswer;
                    break;

                case "multiquiz":
                    question.Type = QuestionType.ManyAnswers;
                    break;

                default:
                    question.Type = QuestionType.Unknown;
                    break;
            }

            foreach (var optionJson in json["options"])
            {
                var option = ParseQuestionOption(optionJson);
                option.Question = question;

                question.Options.Add(option);
            }

            return question;
        }

        private static TestSession ParseTestSession(JToken json)
        {
            var session = new TestSession();

            session.Id                  = json["session"]["id"].Value<int>();
            session.SettingsId          = json["settings"]["id"]?.Value<int?>();
            session.CreatorId           = json["settings"]["account_id"]?.Value<int?>();
            session.TestName            = json["settings"]["name"]?.ToString();
            session.TestQuestionsCount  = json["document"]["questions"].Value<int>();

            foreach (var questionJson in json["questions"])
            {
                var question = ParseTestQuestion(questionJson);
                session.Questions.Add(question);
            }

            return session;
        }

        public static TestSession ParseTestSession(string data)
        {
            return ParseTestSession(JObject.Parse(data));
        }


        private static FlashCard ParseFlashCard(JToken json)
        {
            var flashCard = new FlashCard();

            flashCard.Id                = json["id"].Value<int>();
            flashCard.QuestionContent   = json["question"]["text"].ToString();
            flashCard.AnswerContent     = json["answer"]?["text"].ToString();

            return flashCard;
        }

        private static FlashCard[] ParseFlashCards(JToken json)
        {
            var flashCards = new List<FlashCard>();

            if (json["cards"] is null)
                return flashCards.ToArray();

            foreach (var cardJson in json["cards"])
            {
                var card = ParseFlashCard(cardJson);
                flashCards.Add(card);
            }

            return flashCards.ToArray();
        }

        public static FlashCard[] ParseFlashCards(string data)
        {
            return ParseFlashCards(JObject.Parse(data));
        }


        private static string ParseCsrf(HtmlDocument document)
        {
            return document.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']").Attributes["content"].Value;
        }

        public static string ParseCsrf(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            return ParseCsrf(document);
        }


        private static int GetSessionId(HtmlDocument document)
        {
            var ngInit = document.DocumentNode.SelectSingleNode("//div[@ng-app]").Attributes["ng-init"].Value;
            var regex = new Regex(@"[0-9]+$*");
            var sessionId = regex.Matches(ngInit)[1].Value;

            return int.Parse(sessionId);
        }

        public static int GetSessionId(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            return GetSessionId(document);
        }


        private static string[] GetProfileTestsDocumentsUrls(HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes("//div[@class='items']//a[starts-with(@href, '/test')]");
            var urls = nodes is null ? new string[] { } : nodes.Select(node => node.Attributes["href"].Value).ToArray();
            return urls;
        }

        public static string[] GetProfileTestsDocumentsUrls(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            return GetProfileTestsDocumentsUrls(document);
        }

        private static bool IsLastProfilePage(HtmlDocument document)
        {
            var pagination = document.DocumentNode.SelectSingleNode("//ul[@class='pagination']");
            var disabledNextPageButton = document.DocumentNode.SelectSingleNode("//ul[@class='pagination']/li[@class='next disabled']");

            if (pagination is null || disabledNextPageButton != null)
                return true;

            return false;
        }

        public static bool IsLastProfilePage(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            return IsLastProfilePage(document);
        }
    }
}
