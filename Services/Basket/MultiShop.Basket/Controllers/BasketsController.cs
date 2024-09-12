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
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var value = await _basketService.GetBasketAsync(_loginService.GetUserId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDTO dto)
        {
            dto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasketAsync(dto);
            return Ok("Sepetteki değişiklikler kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasketAsync(_loginService.GetUserId);
            return Ok("Sepet başarıyla silindi");
        }
    }
}
