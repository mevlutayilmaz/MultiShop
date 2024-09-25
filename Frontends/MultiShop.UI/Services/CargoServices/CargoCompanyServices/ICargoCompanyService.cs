using MultiShop.DTOLayer.CargoDTOs.CompanyDTOs;

namespace MultiShop.UI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDTO>> GetAllCargoCompaniesAsync();
        Task<UpdateCargoCompanyDTO> GetByIdCargoCompanyAsync(string id);
        Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO);
        Task DeleteCargoCompanyAsync(string id);
    }
}
