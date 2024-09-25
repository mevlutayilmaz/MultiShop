using Microsoft.AspNetCore.Mvc;
using MultiShop.UI.Services.UserIdentityServices;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;

        public UserController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _userIdentityService.GetAllUsersAsync();
            return View(users);
        }
    }
}
