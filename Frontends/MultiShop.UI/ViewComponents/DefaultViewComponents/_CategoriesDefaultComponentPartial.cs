﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}