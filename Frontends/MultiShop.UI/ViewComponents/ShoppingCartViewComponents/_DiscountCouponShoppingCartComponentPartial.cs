using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ShoppingCartViewComponents
{
    public class _DiscountCouponShoppingCartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
