using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _FooterUserLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
