using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.ProductDetailViewComponents
{
    public class _DescriptionProductDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
