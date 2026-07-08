using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public ISupplierRepository SupplierRepository { get; private set; }

        public IClientRepository ClientRepository { get; private set; }

        public IWareHouseRepository WareHouseRepository { get; private set; }

        public IInventoryRepository InventoryRepository { get; private set; }

        public IMovementInventoryRepository MovementInventory { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }               

        public IOrderDetailRepository OrderDetailRepository { get; private set; }

        public ISaleRepository SaleRepository { get; private set; }

        public ISaleDetailRepository SaleDetailRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
            SupplierRepository = new SupplierRepository(_context);
            ClientRepository = new ClientRepository(_context);
            WareHouseRepository = new WareHouseRepository(_context);
            InventoryRepository = new InventoryRepository(_context);
            MovementInventory = new MovementInventoryRepository(_context);
            OrderRepository = new OrderRepository(_context);
            OrderDetailRepository = new OrderDetailRepository(_context);
            SaleRepository = new SaleRepository(_context);
            SaleDetailRepository = new SaleDetailRepository(_context);

        }
        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region Dispose
        private bool disposed = false;

        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
