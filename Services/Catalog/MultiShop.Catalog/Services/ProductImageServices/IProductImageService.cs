using MultiShop.Catalog.DTOs.ProductImageDTOs;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<IList<ResultProductImageDTO>> GetProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO);
        Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id);
        Task<IList<GetByIdProductImageDTO>> GetByProductIdProductImageAsync(string productId);
    }
}
