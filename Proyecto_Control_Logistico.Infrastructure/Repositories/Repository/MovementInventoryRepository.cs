using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class MovementInventoryRepository : Repository<MovementInventory>, IMovementInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public MovementInventoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovementInventory>> GetMovementInventoryByProductIdAsync(int productId)
        {
            return await _context.MovementInventories
                .Where(x => x.ProductId == productId)
                .Include(x => x.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<MovementInventory>> GetMovementInventoryByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.MovementInventories
                .Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate)
                .Include(x => x.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<MovementInventory>> GetKardexProductoAsync(int productId)
        {
            return await _context.MovementInventories
                .Where(x => x.ProductId == productId)
                .OrderBy(x => x.CreatedAt)
                .Include(x => x.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<MovementInventory>> GetLastMovementsAsync()
        {
            var movements = await _context.MovementInventories
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .OrderByDescending(x=>x.CreatedAt)
                .Take(20)
                .AsNoTracking()
                .ToListAsync();

            return movements;
        }

        public async Task<IEnumerable<MovementInventory>> GetMovementWithWareHouseAsync()
        {
            var result = await _context.MovementInventories
                .Include(x => x.Warehouse)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
    }
}
