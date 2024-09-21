using MultiShop.DTOLayer.CatalogDTOs.BrandDTOs;

namespace MultiShop.UI.Services.CatalogServices.BrandServices
{
	public class BrandService : IBrandService
	{
		private readonly HttpClient _httpClient;
		public BrandService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateBrandAsync(CreateBrandDTO createBrandDTO)
		{
			await _httpClient.PostAsJsonAsync("brands", createBrandDTO);
		}

		public async Task DeleteBrandAsync(string id)
		{
			await _httpClient.DeleteAsync($"brands/{id}");
		}

		public async Task<IList<ResultBrandDTO>> GetAllBrandsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("brands");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDTO>>();
		}

		public async Task<UpdateBrandDTO> GetByIdBrandAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"brands/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDTO>();
		}

		public async Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO)
		{
			await _httpClient.PutAsJsonAsync("brands", updateBrandDTO);
		}
	}
}
