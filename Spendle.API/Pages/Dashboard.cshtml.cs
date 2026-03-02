using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Spendle.API.Data;
using Spendle.API.Models;

namespace Spendle.API.Pages;

public class Dashboard : PageModel
{
    private readonly SpendleDbContext _context;

    public Dashboard(SpendleDbContext context)
    {
        _context = context;
    }
    
    public string? Username{ get; private set; }
    
    public void OnGet()
    {
        Username = HttpContext.Session.GetString("Username");
    }
    
    public async Task<IActionResult> OnPostAsync(string Name, decimal Amount, string Type)
    {
        // Get the current user from the session
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToPage("Login");

        // Create the new transaction
        var transaction = new Transaction
        {
            UserId = userId.Value,
            Name = Name,
            Amount = Type == "Expense" ? -Math.Abs(Amount) : Math.Abs(Amount), // Expenses are negative
            Date = DateTime.Now
        };

        // Save to Azure
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
}