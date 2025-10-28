using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Spendle.API.Services;
using Spendle.API.Helpers;

namespace Spendle.API.Pages
{
    public class Login : PageModel
    {
        private readonly MongoDbService _mongoDbService;

        public Login(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _mongoDbService.GetUserByEmailAsync(Email);

            if (user == null || !PasswordHelper.VerifyPassword(Password, user.HashedPassword))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            return RedirectToPage("/Dashboard");
        }
    }
}