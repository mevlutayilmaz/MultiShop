using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
