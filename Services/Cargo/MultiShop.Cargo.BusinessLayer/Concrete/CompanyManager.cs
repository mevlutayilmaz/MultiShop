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
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal CompanyDal)
        {
            _companyDal = CompanyDal;
        }

        public async Task TDeleteAsync(string id)
        {
            await _companyDal.DeleteAsync(id);
        }

        public IQueryable<Company> TGetAll()
        {
            return _companyDal.GetAll();
        }

        public async Task<Company> TGetByIdAsync(string id)
        {
            return await _companyDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(Company entity)
        {
            await _companyDal.InsertAsync(entity);
        }

        public async Task<int> TSaveAsync()
        {
            return await _companyDal.SaveAsync();
        }

        public void TUpdate(Company entity)
        {
            _companyDal.Update(entity);
        }
    }
}
