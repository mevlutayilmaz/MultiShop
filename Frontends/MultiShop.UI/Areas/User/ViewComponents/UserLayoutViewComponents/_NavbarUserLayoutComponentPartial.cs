using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _NavbarUserLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
