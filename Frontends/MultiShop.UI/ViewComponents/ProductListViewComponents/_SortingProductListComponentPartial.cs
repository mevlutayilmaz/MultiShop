using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductListViewComponents
{
    public class _SortingProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
