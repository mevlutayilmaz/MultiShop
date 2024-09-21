using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;

namespace MultiShop.UI.Services.CatalogServices.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDTO>> GetAllProductsAsync();
		Task CreateProductAsync(CreateProductDTO createProductDTO);
		Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
		Task DeleteProductAsync(string id);
		Task<UpdateProductDTO> GetByIdProductAsync(string id);
		Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync();
		Task<List<ResultProductWithCategoryDTO>> GetProductsByCategoryIdAsync(string categoryId);
	}
}
