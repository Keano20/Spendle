using Microsoft.AspNetCore.Mvc;
using Spendle.API.Data;
using Spendle.API.Models;
using Spendle.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Spendle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SpendleDbContext _context;
    
    public AuthController(SpendleDbContext context)
    {
        _context = context;
    }

    [HttpPost("signup")]
    public IActionResult Signup([FromBody] SignupRequest request)
    {
        // Check if user exists
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (existingUser != null) 
        {
            return BadRequest(new { message = "User already exists." });
        }

        // Create the new user
        var newUser = new User
        {
            Username = request.Username,
            Email = request.Email,
            HashedPassword = PasswordHelper.HashPassword(request.Password)
        };

        // Save to Database
        _context.Users.Add(newUser);
        _context.SaveChanges();

        return Ok(new { message = "Signup successful!" });
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Find user in SQL
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        // Verify Password
        if (user == null || !PasswordHelper.VerifyPassword(request.Password, user.HashedPassword))
        {
            return Unauthorized(new { message = "Invalid email or password." });
        }
        
        return Ok(new { 
            message = "Login successful!", 
            email = user.Email, 
            username = user.Username 
        });
    }
}

public class SignupRequest 
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginRequest 
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}