using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<IList<ResultDiscountCouponDTO>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO);
        Task DeleteDiscountCouponAsync(string id);
        Task<GetByIdDiscountCouponDTO> GetDiscountCouponByIdAsync(string id);
    }
}
