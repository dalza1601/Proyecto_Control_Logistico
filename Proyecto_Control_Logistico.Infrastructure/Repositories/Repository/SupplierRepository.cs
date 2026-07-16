using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Supplier?> GetByRucAsync(string ruc)
        {
            return await _context.Suppliers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RUC == ruc);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersByIdsAsync(List<int> ids)
        {
            return await _context.Suppliers.Where(s=>ids.Contains(s.Id)).ToListAsync();
        }

        public async Task<bool> SupplierExistAsync(string ruc)
        {
            return await _context.Suppliers
                .AnyAsync(x => x.RUC == ruc);
        }
    }
}
