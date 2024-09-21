using MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs;

namespace MultiShop.UI.Services.CatalogServices.FeatureSliderServices
{
	public class FeatureSliderService : IFeatureSliderService
	{
		private readonly HttpClient _httpClient;
		public FeatureSliderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO)
		{
			await _httpClient.PostAsJsonAsync("featuresliders", createFeatureSliderDTO);
		}

		public async Task DeleteFeatureSliderAsync(string id)
		{
			await _httpClient.DeleteAsync($"featuresliders/{id}");
		}

		public async Task<IList<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync()
		{
			var responseMessage = await _httpClient.GetAsync("featuresliders");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDTO>>();
		}

		public async Task<UpdateFeatureSliderDTO> GetByIdFeatureSliderAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"featuresliders/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDTO>();
		}

		public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO)
		{
			await _httpClient.PutAsJsonAsync("featuresliders", updateFeatureSliderDTO);
		}
	}
}
