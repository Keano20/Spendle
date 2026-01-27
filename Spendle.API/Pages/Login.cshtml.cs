using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spendle.API.Data;
using Spendle.API.Helpers;

namespace Spendle.API.Pages
{
    public class Login : PageModel
    {
        private readonly SpendleDbContext _context;

        public Login(SpendleDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            // 1. Find user in SQL
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == Email);

            // 2. Verify Password
            if (user == null || !PasswordHelper.VerifyPassword(Password, user.HashedPassword))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            // 3. Log them in (Session)
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("Username", user.Username);
            
            return RedirectToPage("/Dashboard");
        }
    }
}