using MultiShop.Catalog.DTOs.ProductDTOs;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<IList<ResultProductDTO>> GetProductsAsync();
        Task CreateProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDTO> GetByIdProductAsync(string id);
        Task<IList<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync();
        Task<IList<ResultProductWithCategoryDTO>> GetProductsByCategoryIdAsync(string categoryId);
    }
}
