using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Spendle.API.Pages;

public class Dashboard : PageModel
{
    public string? Username{ get; private set; }
    
    public void OnGet()
    {
        Username = HttpContext.Session.GetString("Username");
    }
}