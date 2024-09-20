using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.IdentityDTOs.LoginDTOs;
using MultiShop.UI.Models;
using MultiShop.UI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.UI.Controllers
{
    public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IIdentityService _identityService;
		public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
		{
			_httpClientFactory = httpClientFactory;
			_identityService = identityService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(SignInDTO signInDTO)
		{
			await _identityService.SignIn(signInDTO);
			return RedirectToAction("Index", "User");
		}
	}
}
