using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
	//[Authorize(LocalApi.PolicyName)]
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

		public AuthsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDTO userLoginDTO)
		{
			var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
			var result = await _signInManager.PasswordSignInAsync(userLoginDTO.Username, userLoginDTO.Password, false, false);
			if (result.Succeeded)
			{
				GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
				model.Username = userLoginDTO.Username;
				model.Id = user.Id;
				var token = TokenHandler.GenerateToken(model);
				return Ok(token);
			}
			else
			{
				return Ok("Kullanıcı Adı veya Şifre Hatalı");
			}
		}
	}
}
