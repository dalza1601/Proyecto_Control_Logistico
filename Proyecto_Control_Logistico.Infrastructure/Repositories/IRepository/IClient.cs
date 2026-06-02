
using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface IClient : IRepository<Client>
    {
        Task<Client?> GetByDniAsync(string dni);
        Task<bool> ClientExistAsync(string dni);
    }
}
