using MultiShop.Basket.DTOs;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasketAsync();
        Task<bool> SaveBasketAsync(BasketTotalDTO basket);
        Task<bool> DeleteBasketAsync();
        Task<bool> RemoveBasketItemAsync(string productId);
        Task<bool> AddBasketItemAsync(BasketItemDTO basketItemDTO);

    }
}
