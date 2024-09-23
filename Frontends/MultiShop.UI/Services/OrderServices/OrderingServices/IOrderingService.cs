using MultiShop.DTOLayer.OrderDTOs.OrderingDTOs;

namespace MultiShop.UI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingDTO>> GetOrderingByUserId();
    }
}
