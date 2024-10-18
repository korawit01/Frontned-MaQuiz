// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using System.Collections.Generic;
// using QuizSystemFrontend.Models;

// namespace QuizSystemFrontend.Pages
// {
//     public class QuizListModel : PageModel
//     {
//         // ตัวแปรสำหรับเก็บข้อมูล quizzes
//         public List<Quiz> Quizzes { get; set; }

//         public void OnGet()
//         {
//             // ตัวอย่างข้อมูล quizzes
//             Quizzes = new List<Quiz>
//             {
//                 new Quiz { Id = 1, Title = "Quiz 1", Description = "Description for quiz 1" },
//                 new Quiz { Id = 2, Title = "Quiz 2", Description = "Description for quiz 2" }
//             };
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using QuizSystemFrontend.Models;  // คลาส Quiz

namespace QuizSystemFrontend.Pages
{
    public class QuizListModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();

        public QuizListModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("https://your-api-url.com/api/quizzes");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Quizzes = JsonSerializer.Deserialize<List<Quiz>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
    }
}
