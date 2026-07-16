using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class WareHouseRepository : Repository<Warehouse>, IWareHouseRepository
    {
        private readonly ApplicationDbContext _context;

        public WareHouseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Warehouse?> GetWareHouseByNameAsync(string name) => await _context.Warehouses
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);
    }
}
