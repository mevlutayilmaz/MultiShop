using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;

namespace MultiShop.UI.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        Task CreateAddressAsync(CreateAddressDTO createAddressDTO);
        Task<ResultAddressDTO> GetAddressByUserIdAsync(string userId);
    }
}
