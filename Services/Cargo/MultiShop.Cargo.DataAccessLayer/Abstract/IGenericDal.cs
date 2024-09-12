using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task InsertAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(string id);
        Task<T> GetByIdAsync(string id);
        IQueryable<T> GetAll();
        Task<int> SaveAsync();
    }
}
