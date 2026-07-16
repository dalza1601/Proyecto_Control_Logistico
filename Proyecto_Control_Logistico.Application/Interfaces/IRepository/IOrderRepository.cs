using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetOrderWithDetailsAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Order>> GetOrdersBySupplierIdAsync(int supplierId);
        Task<string> GenerateUniqueOrderNumberAsync();
        Task<bool> SaveOrderAsync(Order order);
        Task<IEnumerable<Order>> GetLastOrdersAsync();
    }
}
