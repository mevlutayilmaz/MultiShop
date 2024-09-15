using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Areas.Admin.ViewConponents.AdminLayoutViewComponents
{
    public class _ContentHeaderAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
