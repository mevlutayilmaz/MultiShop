using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;
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

		public AuthsController(SignInManager<ApplicationUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDTO userLoginDTO)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDTO.Username, userLoginDTO.Password, false, false);
			if (result.Succeeded) return Ok("Giriş Başarılı");
			return Ok("Kullanıcı Adı veya Şifre Hatalı");
		}
	}
}
