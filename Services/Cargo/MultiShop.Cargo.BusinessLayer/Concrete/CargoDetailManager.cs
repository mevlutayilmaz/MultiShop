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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task TDeleteAsync(string id)
        {
            await _cargoDetailDal.DeleteAsync(id);
        }

        public IQueryable<CargoDetail> TGetAll()
        {
            return _cargoDetailDal.GetAll();
        }

        public async Task<CargoDetail> TGetByIdAsync(string id)
        {
            return await _cargoDetailDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(CargoDetail entity)
        {
            await _cargoDetailDal.InsertAsync(entity);
        }

        public async Task<int> TSaveAsync()
        {
            return await _cargoDetailDal.SaveAsync();
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity);
        }
    }
}
