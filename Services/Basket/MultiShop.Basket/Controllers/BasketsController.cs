using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.DTOs;
using MultiShop.Basket.Services;
using MultiShop.Basket.Services.Login;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var value = await _basketService.GetBasketAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDTO dto)
        {
            await _basketService.SaveBasketAsync(dto);
            return Ok("Sepetteki değişiklikler kaydedildi");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddBasketItem(BasketItemDTO dto)
        {
            await _basketService.AddBasketItemAsync(dto);
            return Ok("Ürün sepete kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasketAsync();
            return Ok("Sepet başarıyla silindi");
        }

        [HttpDelete("[action]/{productId}")]
        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItemAsync(productId);
            return Ok("Ürün başarıyla sepetten silindi");
        }
    }
}
