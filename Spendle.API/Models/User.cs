using System.ComponentModel.DataAnnotations;

namespace Spendle.API.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    public string HashedPassword { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}