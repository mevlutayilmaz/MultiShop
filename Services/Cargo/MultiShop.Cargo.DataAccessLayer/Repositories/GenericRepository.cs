using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task DeleteAsync(string id)
        {
            var value = await Table.FindAsync(Guid.Parse(id));
            Table.Remove(value);
        }

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FindAsync(Guid.Parse(id));
        }

        public async Task InsertAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
