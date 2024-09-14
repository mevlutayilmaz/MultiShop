using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductListViewComponents
{
    public class _PriceFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
