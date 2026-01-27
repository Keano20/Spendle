using Microsoft.EntityFrameworkCore;
using Spendle.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection (SQL Server)
builder.Services.AddDbContext<SpendleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();