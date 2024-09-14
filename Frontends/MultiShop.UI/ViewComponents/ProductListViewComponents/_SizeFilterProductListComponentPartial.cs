using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductListViewComponents
{
    public class _SizeFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
