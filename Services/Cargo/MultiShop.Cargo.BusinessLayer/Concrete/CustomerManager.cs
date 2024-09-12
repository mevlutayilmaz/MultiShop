using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal CustomerDal)
        {
            _customerDal = CustomerDal;
        }

        public async Task TDeleteAsync(string id)
        {
            await _customerDal.DeleteAsync(id);
        }

        public IQueryable<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public async Task<Customer> TGetByIdAsync(string id)
        {
            return await _customerDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(Customer entity)
        {
            await _customerDal.InsertAsync(entity);
        }

        public async Task<int> TSaveAsync()
        {
            return await _customerDal.SaveAsync();
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
