using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizSystemFrontend.Models; // Ensure the namespace is correct
using QuizSystemFrontend.Services; // Ensure the service is correctly referenced
using System.Collections.Generic;
using System.Threading.Tasks;

public class AddQuestionModel : PageModel
{
    private readonly IQuestionService _questionService; // Inject the service

    public AddQuestionModel(IQuestionService questionService)
    {
        _questionService = questionService; // Initialize the service
    }

    [BindProperty]
    public Question NewQuestion { get; set; } = new Question
    {
        Answers = new List<Answer>() // Initialize Answers to avoid null reference
    };

    public void OnGet()
    {
        // Initialization logic for GET requests (if any)
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await _questionService.AddQuestionAsync(NewQuestion); // Call the updated AddQuestionAsync method
            return RedirectToPage("Success"); // Redirect after saving
        }

        return Page(); // Return to the same page if validation fails
    }
}
