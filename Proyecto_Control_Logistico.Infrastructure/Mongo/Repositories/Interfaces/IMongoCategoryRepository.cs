using Proyecto_Control_Logistico.Infrastructure.Mongo.Documents;

namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces
{
    public interface IMongoCategoryRepository: IMongoRepository<CategoryDocument>
    {
        Task<CategoryDocument?> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task UpdateAsync(CategoryDocument category);
    }
}
