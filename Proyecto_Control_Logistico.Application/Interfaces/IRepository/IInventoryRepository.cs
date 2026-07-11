using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
{
    public interface IInventoryRepository : IRepository<Inventary>
    {
        Task<Inventary> GetByProductAsync(int productId);
        Task<IEnumerable<Inventary>> GetStockBajoAsync();
        Task<IEnumerable<Inventary>> GetInventaryFullAsync();
        Task<decimal> GetStockAvailableAsync(int productId);
    }
}
