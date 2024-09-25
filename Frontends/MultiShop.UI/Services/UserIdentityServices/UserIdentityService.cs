using MultiShop.DTOLayer.IdentityDTOs.UserDTOs;

namespace MultiShop.UI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDTO>> GetAllUsersAsync()
        {
            var responseMessage = await _httpClient.GetAsync("/api/users");
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultUserDTO>>();
        }
    }
}
