using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IIventoryRepository : IRepository<Inventary>
    {
        Task<Inventary> GetByProductAsync(int productId);
        Task<IEnumerable<Inventary>> GetStockBajoAsync();
        Task<IEnumerable<Inventary>> GetInventaryFullAsync();
        Task<decimal> GetStockAvailableAsync(int productId);
    }
}
