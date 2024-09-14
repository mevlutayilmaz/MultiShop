using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductDetailViewComponents
{
    public class _FeatureProductDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
