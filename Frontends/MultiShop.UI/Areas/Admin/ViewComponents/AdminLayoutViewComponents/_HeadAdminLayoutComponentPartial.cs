using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Areas.Admin.ViewConponents.AdminLayoutViewComponents
{
    public class _HeadAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
