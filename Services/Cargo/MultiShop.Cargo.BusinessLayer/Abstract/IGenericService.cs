using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsertAsync(T entity);
        void TUpdate(T entity);
        Task TDeleteAsync(string id);
        Task<T> TGetByIdAsync(string id);
        IQueryable<T> TGetAll();
        Task<int> TSaveAsync();
    }
}
