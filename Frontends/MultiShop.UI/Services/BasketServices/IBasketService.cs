using MultiShop.DTOLayer.BasketDTOs;

namespace MultiShop.UI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasketAsync();
        Task RemoveBasketItemAsync(string productId);
        Task AddBasketItemAsync(BasketItemDTO basketItemDTO);
    }
}
