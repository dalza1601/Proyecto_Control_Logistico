using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Application.DTOs;
using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;


namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public Task<IQueryable<Product>> GetAllWithCategory()
        {
            return Task.FromResult(
                _context.Products
                    .Include(x => x.Category)
                    .AsNoTracking()
            );
        }

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product?> GetByCodeAsync(string code)
        {
            return await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<IEnumerable<Product>> GetProductActivesAsync()
        {
            return await _context.Products
                .Include(x => x.Category)
                .Where(x => x.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ProductExistAsync(string code)
        {
            return await _context.Products
                .AnyAsync(x => x.Code == code);
        }
    }
}
