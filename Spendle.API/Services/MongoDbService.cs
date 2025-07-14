using Spendle.API.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

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

}