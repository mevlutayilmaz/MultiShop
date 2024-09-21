using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;

namespace MultiShop.UI.Services.CatalogServices.ProductImageServices
{
	public interface IProductImageService
	{
		Task<IList<ResultProductImageDTO>> GetAllProductImagesAsync();
		Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO);
		Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO);
		Task DeleteProductImageAsync(string id);
		Task<UpdateProductImageDTO> GetByIdProductImageAsync(string id);
		Task<IList<ResultProductImageDTO>> GetByProductIdProductImageAsync(string productId);
	}
}
