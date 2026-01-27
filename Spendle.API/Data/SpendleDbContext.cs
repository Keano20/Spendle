using Microsoft.EntityFrameworkCore;
using Spendle.API.Models;

namespace Spendle.API.Data;
public class SpendleDbContext : DbContext
{
    public SpendleDbContext(DbContextOptions<SpendleDbContext> options) : base(options) { }

    
    public DbSet<User> Users { get; set; }
}