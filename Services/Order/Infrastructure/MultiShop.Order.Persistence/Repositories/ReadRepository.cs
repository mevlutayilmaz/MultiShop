using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Persistence.Contexts;
using System.Linq.Expressions;

namespace MultiShop.Order.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly OrderContext _context;

        public ReadRepository(OrderContext context) => _context = context;

        public DbSet<T> Table => _context.Set<T>();

        public async Task<int> CountAsync(Expression<Func<T, bool>>? method = null)
        {
            Table.AsNoTracking();
            if(method is not null) return await Table.CountAsync(method);
            return await Table.CountAsync();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? method = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            var query = Table.AsQueryable();
            if (!enableTracking) query = query.AsNoTracking();
            if (include is not null) query = include(query);
            if (method is not null) query = query.Where(method);
            if (orderBy is not null) query = orderBy(query);
            return query;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FindAsync(id);
        }
    }
}
