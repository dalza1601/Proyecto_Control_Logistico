using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class InventoryRepository : Repository<Inventary>, IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Inventary> GetByProductAsync(int productId)
        {
            return await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.WareHouse)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<IEnumerable<Inventary>> GetStockBajoAsync()
        {
            // Umbral por defecto para stock bajo; ajustar según requisitos
            const decimal threshold = 10m;

            return await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.WareHouse)
                .Where(x => x.StockAvailable <= threshold)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Inventary>> GetInventaryFullAsync()
        {
            return await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.WareHouse)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<decimal> GetStockAvailableAsync(int productId)
        {
            return await _context.Inventories
                .Where(x => x.ProductId == productId)
                .SumAsync(x => (decimal?)x.StockAvailable) ?? 0m;
        }
    }
}
