using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spendle.API.Data;             
using Spendle.API.Models;
using Spendle.API.Helpers;

namespace Spendle.API.Pages;

public class Signup : PageModel
{
    private readonly SpendleDbContext _context;

    public Signup(SpendleDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public User NewUser { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // 1. Check if user exists using SQL
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == NewUser.Email);

        if (existingUser != null)
        {
            ModelState.AddModelError(string.Empty, "An account with that email already exists.");
            return Page();
        }

        // 2. Hash password
        NewUser.HashedPassword = PasswordHelper.HashPassword(NewUser.HashedPassword);

        // 3. Save to SQL Database
        _context.Users.Add(NewUser);
        await _context.SaveChangesAsync();

        TempData["Message"] = "Account created successfully. Please log in.";
        return RedirectToPage("/Login");
    }
}