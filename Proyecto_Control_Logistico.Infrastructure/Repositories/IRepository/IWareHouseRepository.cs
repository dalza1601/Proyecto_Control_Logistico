using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IWareHouseRepository : IRepository<Warehouse>
    {
        Task<Warehouse> GetWareHouseByNameAsync(string name);
    }
}
