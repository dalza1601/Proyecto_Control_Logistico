
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IClientRepository ClientRepository { get; }
        IWareHouseRepository WareHouseRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IMovementInventoryRepository MovementInventory { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        ISaleRepository SaleRepository { get; }
        ISaleDetailRepository SaleDetailRepository { get; }

        Task<int> SaveAsync();
    }
}
