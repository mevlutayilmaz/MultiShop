using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.UI.Services.CatalogServices.ProductDetailServices
{
	public interface IProductDetailService
	{
		Task<IList<ResultProductDetailDTO>> GetAllProductDetailsAsync();
		Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
		Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
		Task DeleteProductDetailAsync(string id);
		Task<UpdateProductDetailDTO> GetByIdProductDetailAsync(string id);
		Task<UpdateProductDetailDTO> GetByProductIdProductDetailAsync(string productId);
	}
}
