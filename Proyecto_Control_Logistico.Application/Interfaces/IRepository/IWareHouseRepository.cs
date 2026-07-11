using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
{
    public interface IWareHouseRepository : IRepository<Warehouse>
    {
        Task<Warehouse> GetWareHouseByNameAsync(string name);
        Task<List<WareHouseDTO>> GetWareHouseSummaryAsync();
    }
}
