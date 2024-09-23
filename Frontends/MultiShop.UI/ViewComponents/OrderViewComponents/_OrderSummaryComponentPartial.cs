using Microsoft.AspNetCore.Mvc;
using MultiShop.UI.Services.BasketServices;

namespace MultiShop.UI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketService.GetBasketAsync();
            return View(basket);
        }
    }
}
