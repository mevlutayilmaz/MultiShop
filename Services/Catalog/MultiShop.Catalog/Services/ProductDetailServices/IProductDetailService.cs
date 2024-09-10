using MultiShop.Catalog.DTOs.ProductDetailDTOs;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<IList<ResultProductDetailDTO>> GetProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
        Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id);
    }
}
