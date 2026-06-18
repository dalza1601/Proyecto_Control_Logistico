using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces
{
    public interface IMongoRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
    }
}
