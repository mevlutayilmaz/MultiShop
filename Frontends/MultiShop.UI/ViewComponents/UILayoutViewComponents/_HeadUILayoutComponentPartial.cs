using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
