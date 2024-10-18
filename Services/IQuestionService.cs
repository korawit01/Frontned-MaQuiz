using QuizSystemFrontend.Models; // Adjust the namespace as necessary
using QuizSystemFrontend.Services; // Ensure this matches your project structure
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizSystemFrontend.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestionsAsync();
        Task AddQuestionAsync(Question question);
    }
}
