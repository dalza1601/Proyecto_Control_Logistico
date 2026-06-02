using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class WareHouseRepository : Repository<WareHouse>, IWareHouseRepository
    {
        private readonly ApplicationDbContext _context;

        public WareHouseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WareHouse?> GetWareHouseByNameAsync(string name) => await _context.WareHouse
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);
    }
}
