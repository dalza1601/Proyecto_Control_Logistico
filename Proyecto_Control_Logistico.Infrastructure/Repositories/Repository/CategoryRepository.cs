using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Application.Interfaces.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
            .AsNoTracking() // Mejora el rendimiento al no rastrear la entidad
            .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> CategoryExistAsync(string name)
        {
            return await _context.Categories
            .AnyAsync(x => x.Name == name);// Devuelve true si existe una categoría con el nombre dado, de lo contrario false
        }
    }
}
