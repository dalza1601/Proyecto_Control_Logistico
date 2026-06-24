using MongoDB.Driver;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Documents;
using Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories
{
    public class CategoryMongoRepository : MongoRepository<CategoryDocument>, IMongoCategoryRepository
    {
        public CategoryMongoRepository(MongoDbContext context)
        {
            _entity = context.Categories;
        }

        public async Task<CategoryDocument?> GetByIdAsync(string id)
        {
            return await _entity.Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await _entity.DeleteOneAsync(x => x.Id != id);
        }

        public async Task UpdateAsync(CategoryDocument category)
        {
            await _entity.ReplaceOneAsync(
                x => x.Id == category.Id, category);
        }

    }
}
