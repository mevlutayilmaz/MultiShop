using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodOrderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
