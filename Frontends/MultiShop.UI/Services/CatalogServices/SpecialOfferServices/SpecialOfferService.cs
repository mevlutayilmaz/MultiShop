using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.UI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
		private readonly HttpClient _httpClient;
		public SpecialOfferService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO)
		{
			await _httpClient.PostAsJsonAsync("specialoffers", createSpecialOfferDTO);
		}

		public async Task DeleteSpecialOfferAsync(string id)
		{
			await _httpClient.DeleteAsync($"specialoffers/{id}");
		}

		public async Task<IList<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync()
		{
			var responseMessage = await _httpClient.GetAsync("specialoffers");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDTO>>();
		}

		public async Task<UpdateSpecialOfferDTO> GetByIdSpecialOfferAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"specialoffers/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDTO>();
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO)
		{
			await _httpClient.PutAsJsonAsync("specialoffers", updateSpecialOfferDTO);
		}
	}
}
