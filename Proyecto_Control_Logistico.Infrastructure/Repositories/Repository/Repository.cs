using Microsoft.EntityFrameworkCore;
using Proyecto_Control_Logistico.Infrastructure.Data;
using Proyecto_Control_Logistico.Infrastructure.Repositories.IRepository;
using System.Linq.Expressions;

namespace Proyecto_Control_Logistico.Infrastructure.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext cntx;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            cntx = context;
            dbSet = cntx.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string? includeProperties = null)
        {
            var baseQuery = filter != null ? dbSet.Where(filter) : dbSet.AsQueryable();

            var queryWithIncludes = includeProperties != null
                ? includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .Aggregate(baseQuery, (current, include) => current.Include(include))
                : baseQuery;

            return orderBy != null ? Task.FromResult(orderBy(queryWithIncludes).AsEnumerable()) : Task.FromResult(queryWithIncludes.AsEnumerable());
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
        {
            var baseQuery = filter != null ? dbSet.Where(filter) : dbSet.AsQueryable();

            var queryWithIncludes = includeProperties != null
                ? includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .Aggregate(baseQuery, (current, include) => current.Include(include))
                : baseQuery;

            return Task.FromResult(queryWithIncludes.FirstOrDefault());
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
