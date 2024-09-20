﻿using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using Newtonsoft.Json;

namespace MultiShop.UI.Services.CatalogServices.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _httpClient;
		public CategoryService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
		{
			await _httpClient.PostAsJsonAsync<CreateCategoryDTO>("categories", createCategoryDTO);
		}
		public async Task DeleteCategoryAsync(string id)
		{
			await _httpClient.DeleteAsync("categories?id=" + id);
		}
		public async Task<UpdateCategoryDTO> GetByIdCategoryAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("categories/" + id);
			var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDTO>();
			return values;
		}
		public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
		{
			var responseMessage = await _httpClient.GetAsync("categories");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
			return values;
		}
		public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
		{
			await _httpClient.PutAsJsonAsync<UpdateCategoryDTO>("categories", updateCategoryDTO);
		}
	}
}
