using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
{
    public interface ISaleDetailRepository : IRepository<SaleDetail>
    {
        Task<IEnumerable<SaleDetail>> GetSaleDetailsBySaleIdAsync(int saleId);
    }
}
