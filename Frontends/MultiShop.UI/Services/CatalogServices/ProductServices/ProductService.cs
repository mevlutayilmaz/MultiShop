using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MultiShop.UI.Services.CatalogServices.ProductServices
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;
		public ProductService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductAsync(CreateProductDTO createProductDTO)
		{
            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(createProductDTO.Name), "Name");
            content.Add(new StringContent(createProductDTO.Price.ToString()), "Price");
            content.Add(new StringContent(createProductDTO.Description), "Description");
            content.Add(new StringContent(createProductDTO.CategoryId), "CategoryId");

            if (createProductDTO.File != null)
            {
                var fileContent = new StreamContent(createProductDTO.File.OpenReadStream());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(createProductDTO.File.ContentType);
                content.Add(fileContent, "File", createProductDTO.File.FileName);
            }

            var response = await _httpClient.PostAsync("products", content);

            //await _httpClient.PostAsJsonAsync("products", createProductDTO);
		}

		public async Task DeleteProductAsync(string id)
		{
			await _httpClient.DeleteAsync($"products/{id}");
		}

		public async Task<UpdateProductDTO> GetByIdProductAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"products/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateProductDTO>();
		}

		public async Task<List<ResultProductDTO>> GetAllProductsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("products");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDTO>>();
		}

		public async Task<List<ResultProductWithCategoryDTO>> GetProductsByCategoryIdAsync(string categoryId)
		{
			var responseMessage = await _httpClient.GetAsync($"products/GetProductsByCategoryId?categoryId={categoryId}");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDTO>>();
			return values;
		}

		public async Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync()
		{
			var responseMessage = await _httpClient.GetAsync("products/GetProductsWithCategory");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDTO>>();
			return values;
		}

		public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
		{
            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(updateProductDTO.Id), "Id");
            content.Add(new StringContent(updateProductDTO.Name), "Name");
            content.Add(new StringContent(updateProductDTO.Price.ToString()), "Price");
            content.Add(new StringContent(updateProductDTO.Description), "Description");
            content.Add(new StringContent(updateProductDTO.CategoryId), "CategoryId");
            content.Add(new StringContent(updateProductDTO.ImageUrl), "ImageUrl");

            if (updateProductDTO.File != null)
            {
                var fileContent = new StreamContent(updateProductDTO.File.OpenReadStream());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(updateProductDTO.File.ContentType);
                content.Add(fileContent, "File", updateProductDTO.File.FileName);
            }

            await _httpClient.PutAsync("products", content);
		}
	}
}
