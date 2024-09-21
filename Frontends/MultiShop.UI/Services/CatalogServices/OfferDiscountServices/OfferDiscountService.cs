using MultiShop.DTOLayer.CatalogDTOs.OfferDiscountDTOs;

namespace MultiShop.UI.Services.CatalogServices.OfferDiscountServices
{
	public class OfferDiscountService : IOfferDiscountService
	{
		private readonly HttpClient _httpClient;
		public OfferDiscountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO)
		{
			await _httpClient.PostAsJsonAsync("offerdiscounts", createOfferDiscountDTO);
		}

		public async Task DeleteOfferDiscountAsync(string id)
		{
			await _httpClient.DeleteAsync($"offerdiscounts/{id}");
		}

		public async Task<IList<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("offerdiscounts");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultOfferDiscountDTO>>();
		}

		public async Task<UpdateOfferDiscountDTO> GetByIdOfferDiscountAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"offerdiscounts/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDTO>();
		}

		public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO)
		{
			await _httpClient.PutAsJsonAsync("offerdiscounts", updateOfferDiscountDTO);
		}
	}
}
