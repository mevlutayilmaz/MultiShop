using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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
            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(createCategoryDTO.Name), "Name");

            if (createCategoryDTO.File != null)
            {
                var fileContent = new StreamContent(createCategoryDTO.File.OpenReadStream());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(createCategoryDTO.File.ContentType);
                content.Add(fileContent, "File", createCategoryDTO.File.FileName);
            }

            var response = await _httpClient.PostAsync("categories", content);

            //await _httpClient.PostAsJsonAsync("categories", createCategoryDTO);
		}
		public async Task DeleteCategoryAsync(string id)
		{
			await _httpClient.DeleteAsync($"categories/{id}");
		}
		public async Task<UpdateCategoryDTO> GetByIdCategoryAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"categories/{id}");
			var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDTO>();
			return values;
		}
		public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
		{
			var responseMessage = await _httpClient.GetAsync("categories");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDTO>>();
			return values;
		}
		public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
		{
			await _httpClient.PutAsJsonAsync("categories", updateCategoryDTO);
		}
	}
}
