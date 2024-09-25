using MultiShop.DTOLayer.CargoDTOs.CompanyDTOs;

namespace MultiShop.UI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            await _httpClient.PostAsJsonAsync("companies", createCargoCompanyDTO);
        }

        public async Task DeleteCargoCompanyAsync(string id)
        {
            await _httpClient.DeleteAsync($"companies/{id}");
        }

        public async Task<List<ResultCargoCompanyDTO>> GetAllCargoCompaniesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("companies");
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDTO>>();
        }

        public async Task<UpdateCargoCompanyDTO> GetByIdCargoCompanyAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"companies/{id}");
            return await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDTO>();
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            await _httpClient.PutAsJsonAsync("companies", updateCargoCompanyDTO);
        }
    }
}
