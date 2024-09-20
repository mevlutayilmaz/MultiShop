using MultiShop.DTOLayer.IdentityDTOs.LoginDTOs;

namespace MultiShop.UI.Services.Interfaces
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDTO signInDTO);
		Task<bool> GetRefreshToken();
	}
}
