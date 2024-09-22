using Microsoft.AspNetCore.Mvc;
using MultiShop.UI.Services.BasketServices;

namespace MultiShop.UI.ViewComponents.ShoppingCartViewComponents
{
    public class _TotalAmountShoppingCartComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _TotalAmountShoppingCartComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int rate = 0;
            string codeName = null;
            if (ViewData["codeRate"] != null)
            {
                rate = int.Parse(ViewData["codeRate"].ToString());
                codeName = ViewData["codeName"].ToString();
            }
            var values = await _basketService.GetBasketAsync();
            values.DiscountRate = rate;
            values.DiscountCode = codeName;
            return View(values);
        }
    }
}
