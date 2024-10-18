using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using QuizSystemFrontend.Models; // Ensure the namespace is correct

namespace QuizSystemFrontend.Services // Make sure the namespace matches your project structure
{
    public class QuestionService : IQuestionService
    {
        private readonly HttpClient _httpClient;

        public QuestionService(HttpClient httpClient)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler);
        }

        public async Task<List<Question>> GetQuestionsAsync()
        {
            var questions = await _httpClient.GetFromJsonAsync<List<Question>>("https://localhost:5001/api/Question");
            return questions ?? new List<Question>(); // Return an empty list if null
        }

        public async Task AddQuestionAsync(Question question)
        {
            // Send a POST request to the API to add the question
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/Question", question);
            response.EnsureSuccessStatusCode(); // Throws if not successful
        }
    }
}
