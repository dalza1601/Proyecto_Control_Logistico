using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order?> GetOrderWithDetailsAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Include(o => o.Supplier)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => o.DateOrder >= startDate && o.DateOrder <= endDate)
                .Include(o => o.Supplier)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersBySupplierIdAsync(int supplierId)
        {
            return await _context.Orders
                .Where(o => o.SupplierId == supplierId)
                .Include(o => o.OrderDetails)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<string> GenerateUniqueOrderNumberAsync()
        {
            var last = await _context.Orders
                .OrderByDescending(o => o.Id)
                .FirstOrDefaultAsync();

            var next = (last?.Id ?? 0) + 1;
            return $"ORD-{DateTime.Now:yyyyMMdd}-{next:D6}";
        }

        public async Task<bool> SaveOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Order>> GetLastOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Supplier)
                .AsNoTracking()
                .OrderByDescending(o => o.CreatedAt)
                .Take(20)
                .ToListAsync();
        }
    }
}
