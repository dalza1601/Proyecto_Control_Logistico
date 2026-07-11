using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IMovementInventoryRepository : IRepository<MovementInventory>
    {
        Task<IEnumerable<MovementInventory>> GetMovementInventoryByProductIdAsync(int productId);
        Task<IEnumerable<MovementInventory>> GetMovementInventoryByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<MovementInventory>> GetKardexProductoAsync(int productId);

    }
}
