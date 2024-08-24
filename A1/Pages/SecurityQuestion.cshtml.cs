using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A1.Pages
{
    public class SecurityQuestionModel : PageModel
    {
        public string correctAnswer = "chaotang";
        public void OnGet()
        {
        }


        // Correct answer redirects to Register page
        public IActionResult OnPostAsync(string answer)
        {
            if (answer == correctAnswer)
            {
                return RedirectToPage("Register");
            }
            return Page();
        }
    }
}
