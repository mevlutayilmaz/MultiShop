using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ShoppingCartViewComponents
{
    public class _ProductListShoppingCartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
