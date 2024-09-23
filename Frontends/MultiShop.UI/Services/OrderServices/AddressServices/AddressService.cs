using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;

namespace MultiShop.UI.Services.OrderServices.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAddressAsync(CreateAddressDTO createAddressDTO)
        {
            await _httpClient.PostAsJsonAsync("addresses", createAddressDTO);
        }

        public async Task<ResultAddressDTO> GetAddressByUserIdAsync(string userId)
        {
            var responseMessage = await _httpClient.GetAsync($"addresses/GetAddressByUserId?userId={userId}");
            return await responseMessage.Content.ReadFromJsonAsync<ResultAddressDTO>();
        }
    }
}
