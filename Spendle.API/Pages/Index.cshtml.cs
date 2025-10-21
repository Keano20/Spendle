using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Spendle.API.Pages;

public class Index : PageModel
{
    public string? LoggedEmail{ get; private set; }
    
    public void OnGet()
    {
        LoggedEmail = HttpContext.Session.GetString("UserEmail");
    }
}