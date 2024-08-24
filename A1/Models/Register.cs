using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A1.Models
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<Staff> _userManager;

        public RegisterModel(UserManager<Staff> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string StaffId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string Position { get; set; }
            public string WorkEmail { get; set; }
            public string WorkPhone { get; set; }
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var staff = new Staff
            {
                StaffId = Input.StaffId,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Password = Input.Password,
                Position = Input.Position,
                WorkEmail = Input.WorkEmail,
                WorkPhone = Input.WorkPhone
            };

            var result = _userManager.CreateAsync(staff, Input.Password).Result;

            if (result.Succeeded)
            {
                return RedirectToPage("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
