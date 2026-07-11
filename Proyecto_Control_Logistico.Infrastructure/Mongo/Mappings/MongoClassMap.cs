using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Documents;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Mappings
{
    public static class MongoClassMap
    {
        public static void RegisterMappings()
        {

            //registramos todas las entidades que vayamos a utilizar
            if (!BsonClassMap.IsClassMapRegistered(typeof(MongoDocument)))
            {
                BsonClassMap.RegisterClassMap<MongoDocument>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(c => c.Id)
                        .SetIdGenerator(StringObjectIdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.ObjectId));
                });
            }
            if (!BsonClassMap.IsClassMapRegistered(typeof(CategoryDocument)))
            {
                BsonClassMap.RegisterClassMap<CategoryDocument>(cm =>
                {
                    cm.AutoMap();
                });
            }

        }
    }
}
