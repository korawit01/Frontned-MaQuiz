// Pages/Questions.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizSystemFrontend.Models; // Make sure this namespace is correct
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizSystemFrontend.Services; 

public class QuestionsModel : PageModel
{
    private readonly IQuestionService _questionService;

    public QuestionsModel(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    // public List<Question> Questions { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();


    public async Task OnGetAsync()
    {
        Questions = await _questionService.GetQuestionsAsync();
    }
}
