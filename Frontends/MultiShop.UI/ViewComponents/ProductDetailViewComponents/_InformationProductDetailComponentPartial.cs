using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductDetailViewComponents
{
    public class _InformationProductDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
