using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace NaOtvet
{
    public class RequestsSender
    {
        public const string BaseUrl = "https://naurok.com.ua";
        private CookieContainer cookies = new CookieContainer();
        private RestClient client = new RestClient(BaseUrl);

        public RequestsSender()
        {
            client.CookieContainer = cookies;
        }

        public async Task<IRestResponse> GetLoginPage()
        {
            var request = new RestRequest("/login");
            return await client.ExecuteGetAsync(request);
        }

        public IRestResponse GetTestingPage(string sessionUuid)
        {
            var request = new RestRequest($"/test/testing/{sessionUuid}");
            return client.Get(request);
        }

        public async Task<IRestResponse> Autorization(string login, string password, string csrf)
        {
            var request = new RestRequest("/login");
            request.AddParameter("_csrf", csrf);
            request.AddParameter("LoginForm[login]", login);
            request.AddParameter("LoginForm[password]", password);

            return await client.ExecutePostAsync(request);
        }

        public IRestResponse GetSession(int id)
        {
            var request = new RestRequest($"/api2/test/sessions/{id}");
            return client.Get(request);
        }

        public IRestResponse GetFlashCards(int documentId)
        {
            var request = new RestRequest($"/api/test/documents/{documentId}/flashcard");
            request.AddHeader("Referer", $"{BaseUrl}/test/{documentId}/flashcard");

            return client.Post(request);
        }

        public async Task<IRestResponse> GetProfileTests(int profileId, int page)
        {
            var request = new RestRequest($"/profile/{profileId}?storinka={page}");
            return await client.ExecuteGetAsync(request);
        }

        /*public async Task<IRestResponse> PutAnswer(int sessionId, QuestionOption[] answers)
        {
            var request = new RestRequest($"/api2/test/responses/answer", Method.PUT, DataFormat.Json);
            var body = new
            {
                session_id  = sessionId,
                question_id = answers.First().Question.Id.ToString(),
                point       = answers.First().Question.Points.ToString(),
                answer      = answers.Select(answer => answer.Id.ToString()).ToArray(),
                homework    = true,
                show_answer = 0,
                type        = "quiz",
                homeworkType = 1
            };

            request.AddJsonBody(JsonConvert.SerializeObject(body));

            return await client.ExecuteAsync(request);
        }*/
    }
}
