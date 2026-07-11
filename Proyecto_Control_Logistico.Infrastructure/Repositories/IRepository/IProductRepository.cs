using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByCodeAsync(string code);
        Task<IEnumerable<Product>> GetProductActivesAsync();
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);
        Task<bool> ProductExistAsync(string code);

        Task<IQueryable<Product>> GetAllWithCategory();
    }
}
