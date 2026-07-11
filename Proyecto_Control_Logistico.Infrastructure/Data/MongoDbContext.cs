using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Proyecto_Control_Logistico.Infrastructure.Mongo;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Documents;

namespace Proyecto_Control_Logistico.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        //agregamos las entidades
        public IMongoCollection<CategoryDocument> Categories => _database.GetCollection<CategoryDocument>("Categories");
    }
}
