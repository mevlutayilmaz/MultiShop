using MultiShop.DTOLayer.IdentityDTOs.UserDTOs;

namespace MultiShop.UI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDTO>> GetAllUsersAsync();
    }
}
