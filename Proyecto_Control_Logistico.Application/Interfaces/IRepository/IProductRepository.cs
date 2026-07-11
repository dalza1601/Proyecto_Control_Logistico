using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByCodeAsync(string code);
        Task<IEnumerable<Product>> GetProductActivesAsync();
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);
        Task<bool> ProductExistAsync(string code);
        Task<int> ActiveProductsCountAsync();
    }
}
