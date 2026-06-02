using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IWareHouse : IRepository<WareHouse>
    {
        Task<WareHouse> GetWareHouseByNameAsync(string name);
    }
}
