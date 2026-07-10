using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Application.Interfaces.IRepository
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Task<Sale?> GetSaleWithDetailsAsync(int id);
        Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Sale>> GetSalesByCustomerIdAsync(int customerId);
        Task<string> GenerateUniqueSaleNumberAsync();

    }
}
