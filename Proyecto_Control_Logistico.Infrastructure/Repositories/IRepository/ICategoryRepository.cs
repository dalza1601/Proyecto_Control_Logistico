using Proyecto_Control_Logistico.Domain.Entities;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
        Task<bool> CategoryExistAsync(string name);
    }
}
