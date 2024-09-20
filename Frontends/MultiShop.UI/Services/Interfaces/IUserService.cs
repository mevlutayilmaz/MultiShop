using MultiShop.UI.Models;

namespace MultiShop.UI.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDetailViewModel> GetUserInfo();
	}
}
