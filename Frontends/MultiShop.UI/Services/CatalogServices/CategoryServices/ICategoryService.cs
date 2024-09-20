using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;

namespace MultiShop.UI.Services.CatalogServices.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
		Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);
		Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
		Task DeleteCategoryAsync(string id);
		Task<UpdateCategoryDTO> GetByIdCategoryAsync(string id);
	}
}
