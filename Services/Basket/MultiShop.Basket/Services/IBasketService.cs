using MultiShop.Basket.DTOs;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasketAsync(string userId);
        Task<bool> SaveBasketAsync(BasketTotalDTO basket);
        Task<bool> DeleteBasketAsync(string userId);
    }
}
