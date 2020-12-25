using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NaUrokApiClient
{
    static class ResponsesParser
    {
        private static QuestionOption ParseQuestionOption(JToken json, out bool? isCorrect)
        {
            var option = new QuestionOption();

            option.Id       = json["id"].Value<int>();
            option.HtmlText = json["value"].ToString();

            if (json["image"] != null && json["image"].Type != JTokenType.Null)
                option.ImageUrl = json["image"].ToString();

            if (json["correct"] is null)
                isCorrect = null;
            else
                isCorrect = Convert.ToBoolean(json["correct"].Value<int>());

            return option;
        }

        private static TestQuestion ParseTestQuestion(JToken json)
        {
            var question = new TestQuestion();

            question.Id         = json["id"].Value<int>();
            question.HtmlText   = json["content"].ToString();
            question.Points     = json["point"].Value<int>();
            
            if (json["image"] != null && json["image"].Type != JTokenType.Null)
                question.ImageUrl = json["image"].ToString();

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
                var option = ParseQuestionOption(optionJson, out bool? isCorrect);
                option.Question = question;

                question.Options.Add(option);

                if (isCorrect.HasValue && isCorrect.Value)
                    question.Answers.Add(option);
            }

            return question;
        }

        private static TestSession ParseTestSession(JToken json)
        {
            var session = new TestSession();

            session.Id                  = json["session"]["id"].Value<int>();
            session.UuId                = json["session"]["uuid"].ToString();
            session.SettingsId          = json["settings"]["id"]?.Value<int?>();
            session.CreatorId           = json["settings"]["account_id"]?.Value<int?>();
            session.TestName            = json["settings"]["name"]?.ToString();
            session.StartDateTime       = DateTimeOffset.FromUnixTimeSeconds(json["session"]["start_at"].Value<long>()).LocalDateTime;

            bool showTimer;

            if (json["settings"]["show_timer"] is null)
                showTimer = false;
            else
                showTimer = json["settings"]["show_timer"].Value<bool>();

            if (json["settings"]["duration"] != null && showTimer)
                session.Duration = TimeSpan.FromMinutes(json["settings"]["duration"].Value<int>());

            if (json["settings"]["deadline"] != null && json["settings"]["deadline"].Type != JTokenType.Null)
                session.TestEndDateTime = DateTimeOffset.FromUnixTimeSeconds(json["settings"]["deadline"].Value<long>()).LocalDateTime;

            if (json["settings"]["created_at"] != null)
                session.TestStartDateTime = DateTimeOffset.FromUnixTimeSeconds(json["settings"]["created_at"].Value<long>()).LocalDateTime;

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
            flashCard.QuestionHtmlText  = json["question"]["text"].ToString();
            flashCard.QuestionImageUrl  = json["question"]["image"]?.ToString();
            flashCard.AnswerHtmlText    = json["answer"]?["text"].ToString();
            flashCard.AnswerImageUrl    = json["answer"]?["image"]?.ToString();

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


        private static TestDocument ParseTestDocumentId(JToken json)
        {
            var document = new TestDocument();
            document.Id         = json["id"].Value<int>();
            document.Slug       = json["slug"].ToString();
            document.Name       = json["name"].ToString();
            document.Author     = json["author"].ToString();
            document.Subject    = json["subject"].ToString();
            document.Grade      = json["grade"].ToString();

            foreach (var questionJson in json["questions"])
            {
                var question = ParseTestQuestion(questionJson);
                document.Questions.Add(question);
            }

            return document;
        }

        private static TestDocument[] ParseTestsDocumentsId(JArray json)
        {
            var documents = new List<TestDocument>();

            foreach (var document in json)
            {
                var id = ParseTestDocumentId(document);
                documents.Add(id);
            }

            return documents.ToArray();
        }

        public static TestDocument ParseTestDocument(string data)
        {
            return ParseTestDocumentId(JObject.Parse(data));
        }

        public static TestDocument[] ParseTestsDocuments(string data)
        {
            return ParseTestsDocumentsId(JArray.Parse(data));
        }
    }
}
