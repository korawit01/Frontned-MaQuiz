using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; // เพิ่มบรรทัดนี้เพื่อใช้ PageModel
using QuizSystemFrontend.Models;


namespace QuizSystemFrontend.Pages
{
    public class CreateQuizModel : PageModel
    {
        [BindProperty]
        public Quiz Quiz { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Logic for creating a quiz

            return RedirectToPage("Index");
        }
    }
}
