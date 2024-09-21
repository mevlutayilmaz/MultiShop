﻿using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using Newtonsoft.Json;
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
			await _httpClient.PostAsJsonAsync("products", createProductDTO);
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
			await _httpClient.PutAsJsonAsync("products", updateProductDTO);
		}
	}
}
