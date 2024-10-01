using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using System.Net.Http.Headers;

namespace MultiShop.UI.Services.CatalogServices.ProductImageServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly HttpClient _httpClient;
		public ProductImageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
		{
			using var content = new MultipartFormDataContent();

			content.Add(new StringContent(createProductImageDTO.ProductId), "ProductId");

            foreach (var file in createProductImageDTO.Files)
            {
				var fileContent = new StreamContent(file.OpenReadStream());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);
                content.Add(fileContent, "Files", file.FileName);
            }
            await _httpClient.PostAsync("productimages", content);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _httpClient.DeleteAsync($"productimages/{id}");
		}

		public async Task<IList<ResultProductImageDTO>> GetAllProductImagesAsync()
		{
			var responseMessage = await _httpClient.GetAsync("productimages");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDTO>>();
		}

		public async Task<UpdateProductImageDTO> GetByIdProductImageAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"productimages/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDTO>();
		}

		public async Task<IList<ResultProductImageDTO>> GetByProductIdProductImageAsync(string productId)
		{
			var responseMessage = await _httpClient.GetAsync($"productimages/GetProductImageByProductId/{productId}");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDTO>>();
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
		{
			await _httpClient.PutAsJsonAsync("productimages", updateProductImageDTO);
		}

	}
}
