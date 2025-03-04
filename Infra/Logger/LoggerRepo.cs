using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;

namespace Infra.Logger;

public class LoggerRepo : ILoggerRepo
{
    private readonly string _connectionString;

    public LoggerRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Task Create(object log)
    {     

        var client = new MongoClient(_connectionString);

        var database = client.GetDatabase("Logger");

        var collection = database.GetCollection<BsonDocument>("Log");

        var json = JsonSerializer.Serialize(log);

        var document = BsonDocument.Parse(json);

        return collection.InsertOneAsync(document);

    }
}
