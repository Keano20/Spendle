using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Spendle.API.Models;
using Spendle.API.Services;
using Spendle.API.Helpers;

namespace Spendle.API.Pages;

public class Signup : PageModel
{
    private readonly MongoDbService _mongoDbService;

    public Signup(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [BindProperty]
    public User NewUser { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existing = await _mongoDbService.GetUserByEmailAsync(NewUser.Email);
        if (existing != null)
        {
            ModelState.AddModelError(string.Empty, "An account with that email already exists.");
            return Page();
        }

        NewUser.HashedPassword = PasswordHelper.HashPassword(NewUser.HashedPassword);

        await _mongoDbService.CreateUserAsync(NewUser);

        TempData["Message"] = "Account created successfully. Please log in.";
        return RedirectToPage("/Login");
    }
}