using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
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

        public async Task<List<WarehouseDTO>> GetWareHouseSummaryAsync()
        {
            var result = await _context.MovementInventories
                .Join(
                    _context.Warehouses,
                    movement => movement.WareHouseId,
                    warehouse => warehouse.Id,
                    (movement, warehouse) => new { movement, warehouse }
                )
                .GroupBy(x => x.warehouse.Name)
                .Select(g => new WarehouseDTO
                {
                    Name = g.Key,
                    Inputs = g.Count(x => x.movement.MovementType == "Entrada"),
                    Outputs = g.Count(x => x.movement.MovementType == "Salida")
                })
                .ToListAsync();
            return result;
        }
    }
}
