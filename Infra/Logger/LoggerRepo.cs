using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;

namespace Infra.Logger;

public class LoggerRepo : ILoggerRepo
{
    public Task Create(object log)
    {
        var connectionString = "mongodb://localhost:27017";

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("Logger");

        var collection = database.GetCollection<BsonDocument>("Log");

        var json = JsonSerializer.Serialize(log);

        var document = BsonDocument.Parse(json);

        return collection.InsertOneAsync(document);

    }
}
