using Spendle.API.Config;
using Spendle.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mongo Config
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();

// Mongo connection check
using (var scope = app.Services.CreateScope())
{
    var mongoCheck = scope.ServiceProvider.GetRequiredService<MongoDbService>();
}

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