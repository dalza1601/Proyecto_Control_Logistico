
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client?> GetByDniAsync(string dni);
        Task<bool> ClientExistAsync(string dni);
    }
}
