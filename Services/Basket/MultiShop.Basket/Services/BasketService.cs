using MultiShop.Basket.DTOs;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<bool> DeleteBasketAsync(string userId)
        {
            return await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDTO> GetBasketAsync(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDTO>(existBasket);
        }

        public async Task<bool> SaveBasketAsync(BasketTotalDTO basket)
        {
            return await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
        }
    }
}
