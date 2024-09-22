using MultiShop.Basket.DTOs;
using MultiShop.Basket.Services.Login;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        private readonly ILoginService _loginService;

        public BasketService(RedisService redisService, ILoginService loginService)
        {
            _redisService = redisService;
            _loginService = loginService;
        }

        public async Task<bool> AddBasketItemAsync(BasketItemDTO basketItemDTO)
        {
            var basket = await GetBasketAsync();
            var itemToUpdate = basket.BasketItems.FirstOrDefault(item => item.ProductId == basketItemDTO.ProductId);
            if (itemToUpdate is not null)
            {
                itemToUpdate.Quantity += basketItemDTO.Quantity;
            }
            else
            {
                basket.BasketItems.Add(basketItemDTO);
            }
            return await SaveBasketAsync(basket);
        }

        public async Task<bool> DeleteBasketAsync()
        {
            return await _redisService.GetDb().KeyDeleteAsync(_loginService.GetUserId);
        }

        public async Task<bool> RemoveBasketItemAsync(string productId)
        {
            var basket = await GetBasketAsync();
            var deletedItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == productId);
            if (deletedItem != null)
            {
                basket.BasketItems.Remove(deletedItem);
                return await SaveBasketAsync(basket);
            }
            return false;
        }

        public async Task<BasketTotalDTO> GetBasketAsync()
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(_loginService.GetUserId);
            if (existBasket.IsNullOrEmpty)
            {
                var basket = new BasketTotalDTO
                {
                    UserId = _loginService.GetUserId,
                    DiscountCode = "yok",
                    DiscountRate = 0,
                    BasketItems = new List<BasketItemDTO>()
                };
                await SaveBasketAsync(basket);
                return basket;
            }
            return JsonSerializer.Deserialize<BasketTotalDTO>(existBasket);
        }

        public async Task<bool> SaveBasketAsync(BasketTotalDTO basket)
        {
            return await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
        }
    }
}
