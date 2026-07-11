using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Application.DTOs;

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

        public async Task<IEnumerable<MovementInventoryDTO>> GetLastMovementsAsync()
        {
            var movements = await _context.MovementInventories
                .Join(_context.Products,
                    t0 => t0.ProductId,
                    t1 => t1.Id,
                    (t0, t1) => new { t0, t1 })
                .Join(_context.Warehouses,
                    combined => combined.t0.WareHouseId,
                    t2 => t2.Id,
                    (combined, t2) => new MovementInventoryDTO
                    {
                        ProductName = combined.t1.Name,
                        WareHouse = t2.Name,
                        MovementType = combined.t0.MovementType,
                        Quantity = combined.t0.Quantity,
                        Motive = combined.t0.Motive,
                        Date = combined.t0.CreatedAt
                    })
                .ToListAsync();

            return movements;
        }
    }
}
