using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IWareHouseRepository : IRepository<WareHouse>
    {
        Task<WareHouse> GetWareHouseByNameAsync(string name);
    }
}
