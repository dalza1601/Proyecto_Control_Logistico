using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Documents
{
    public abstract class MongoDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
