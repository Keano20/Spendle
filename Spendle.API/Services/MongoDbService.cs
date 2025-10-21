using Spendle.API.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using Spendle.API.Models;

namespace Spendle.API.Services;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        try
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _database.RunCommand<BsonDocument>("{ping:1}");
            Console.WriteLine($"Spendle is connected to: {mongoDbSettings.Value.DatabaseName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"MongoDB connection failed: {ex.Message}");
        }
    }
    public  IMongoDatabase GetDatabase() => _database;
    
    public async Task CreateUserAsync(User user)
    {
        var users = _database.GetCollection<User>("Users");
        await users.InsertOneAsync(user);
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var users = _database.GetCollection<User>("Users");
        return await users.Find(u => u.Email == email).FirstOrDefaultAsync();
    }

}