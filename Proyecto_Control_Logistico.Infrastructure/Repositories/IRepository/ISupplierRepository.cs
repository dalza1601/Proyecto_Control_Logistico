using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier?> GetByRucAsync(string ruc);
        Task<bool> SupplierExistAsync(string ruc);
    }
}
