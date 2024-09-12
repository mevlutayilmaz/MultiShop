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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal CargoOperationDal)
        {
            _cargoOperationDal = CargoOperationDal;
        }

        public async Task TDeleteAsync(string id)
        {
            await _cargoOperationDal.DeleteAsync(id);
        }

        public IQueryable<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public async Task<CargoOperation> TGetByIdAsync(string id)
        {
            return await _cargoOperationDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(CargoOperation entity)
        {
            await _cargoOperationDal.InsertAsync(entity);
        }

        public async Task<int> TSaveAsync()
        {
            return await _cargoOperationDal.SaveAsync();
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}
