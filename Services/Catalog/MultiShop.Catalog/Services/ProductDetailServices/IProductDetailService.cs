using MultiShop.Catalog.DTOs.ProductDetailDTOs;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<IList<ResultProductDetailDTO>> GetProductDetailsAsync();
        Task<GetByProductIdProductDetailDTO> CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
        Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id);
        Task<GetByProductIdProductDetailDTO> GetByProductIdProductDetailAsync(string productId);
    }
}
