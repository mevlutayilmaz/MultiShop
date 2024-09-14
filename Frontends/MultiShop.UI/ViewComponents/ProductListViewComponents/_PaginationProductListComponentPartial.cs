using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductListViewComponents
{
    public class _PaginationProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
