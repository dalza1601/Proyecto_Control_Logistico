using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class SaleDetailRepository : Repository<SaleDetail>, ISaleDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleDetail>> GetSaleDetailsBySaleIdAsync(int saleId)
        {
            return await _context.SaleDetails
                .Where(sd => sd.SaleId == saleId)
                .Include(sd => sd.Product)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
