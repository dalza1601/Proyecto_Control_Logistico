using MongoDB.Driver;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        internal IMongoCollection<T> _entity;

        public async Task AddAsync(T entity)
        {
           await _entity.InsertOneAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entity.Find(_ => true)// Trae a todos los objetos encontrados, similar a un Select * from
                .ToListAsync();
        }

    }
}
