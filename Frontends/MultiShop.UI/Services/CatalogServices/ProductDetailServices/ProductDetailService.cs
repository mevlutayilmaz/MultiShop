using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.UI.Services.CatalogServices.ProductDetailServices
{
	public class ProductDetailService : IProductDetailService
	{
		private readonly HttpClient _httpClient;
		public ProductDetailService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
		{
			await _httpClient.PostAsJsonAsync("productdetails", createProductDetailDTO);
		}

		public async Task DeleteProductDetailAsync(string id)
		{
			await _httpClient.DeleteAsync($"productdetails/{id}");
		}

		public async Task<IList<ResultProductDetailDTO>> GetAllProductDetailsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("productdetails");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDTO>>();
		}

		public async Task<UpdateProductDetailDTO> GetByIdProductDetailAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"productdetails/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDTO>();
		}

		public async Task<UpdateProductDetailDTO> GetByProductIdProductDetailAsync(string productId)
		{
			var responseMessage = await _httpClient.GetAsync($"productdetails/GetByProductIdProductDetail/{productId}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDTO>();
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
		{
			await _httpClient.PutAsJsonAsync("productdetails", updateProductDetailDTO);
		}
	}
}
