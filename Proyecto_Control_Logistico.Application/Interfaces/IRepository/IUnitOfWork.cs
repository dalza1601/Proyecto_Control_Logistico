namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
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
