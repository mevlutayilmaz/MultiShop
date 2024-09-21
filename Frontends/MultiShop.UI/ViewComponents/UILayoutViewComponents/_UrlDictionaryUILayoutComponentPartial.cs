using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.UILayoutViewComponents
{
    public class _UrlDictionaryUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
