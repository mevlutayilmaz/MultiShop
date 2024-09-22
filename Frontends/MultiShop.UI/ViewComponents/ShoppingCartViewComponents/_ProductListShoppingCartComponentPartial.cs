using Microsoft.AspNetCore.Mvc;
using MultiShop.UI.Services.BasketServices;

namespace MultiShop.UI.ViewComponents.ShoppingCartViewComponents
{
    public class _ProductListShoppingCartComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ProductListShoppingCartComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketService.GetBasketAsync();
            return View(basket.BasketItems);
        }
    }
}
