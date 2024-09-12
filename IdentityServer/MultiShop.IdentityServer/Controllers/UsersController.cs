using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDTO dto)
        {
            IdentityResult result = await _userManager.CreateAsync(new ApplicationUser()
            {
                Email = dto.Email,
                Surname = dto.Surname,
                Name = dto.Name,
                UserName = dto.Username,
            }, dto.Password);

            if (result.Succeeded) return Ok("Kayıt işlemi başarılı");
            return Ok("Kayıt sırasında bir hata meydana geldi");
        }
    }
}
