using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductListViewComponents
{
    public class _ColorFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
