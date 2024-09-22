using MultiShop.DTOLayer.DiscountDTOs;

namespace MultiShop.UI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<IList<ResultDiscountCouponDTO>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO);
        Task DeleteDiscountCouponAsync(string id);
        Task<UpdateDiscountCouponDTO> GetDiscountCouponByIdAsync(string id);
        Task<ResultDiscountCouponDTO> GetDiscountCouponByCodeAsync(string code);
    }
}
