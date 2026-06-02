using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Sale?> GetSaleWithDetailsAsync(int id)
        {
            return await _context.Sales
                .Include(s => s.SaleDetails)
                .ThenInclude(sd => sd.Product)
                .Include(s => s.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Sales
                .Where(s => s.DateSale >= startDate && s.DateSale <= endDate)
                .Include(s => s.Client)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesByCustomerIdAsync(int customerId)
        {
            return await _context.Sales
                .Where(s => s.ClientId == customerId)
                .Include(s => s.SaleDetails)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<string> GenerateUniqueSaleNumberAsync()
        {
            var last = await _context.Sales
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            var next = (last?.Id ?? 0) + 1;
            return $"SAL-{DateTime.Now:yyyyMMdd}-{next:D6}";
        }
    }
}
