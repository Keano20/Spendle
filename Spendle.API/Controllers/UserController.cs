using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Spendle.API.Models;
using Spendle.API.Services;

namespace Spendle.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMongoCollection<User> _users;

    public UserController(IMongoCollection<User> users)
    {
        
    }
}