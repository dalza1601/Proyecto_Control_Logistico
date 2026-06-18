using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories
{
    public class MongoUnitOfWork : IMongoUnitOfWork
    {
        private readonly MongoDbContext _context;
        public IMongoCategoryRepository MongoCategoryRepository { get; private set; }

        public MongoUnitOfWork(MongoDbContext context)
        {
            _context = context;
            MongoCategoryRepository = new CategoryMongoRepository(_context);
        }
    }
}
