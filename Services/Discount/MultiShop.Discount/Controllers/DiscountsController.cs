using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCoupons()
        {
            var value = await _discountService.GetAllDiscountCouponsAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(string id)
        {
            var value = await _discountService.GetDiscountCouponByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDiscountCouponByCode(string code)
        {
            var value = await _discountService.GetDiscountCouponByCodeAsync(code);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDTO createCouponDTO)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDTO);
            return Ok("Coupon başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDTO updateCouponDTO)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDTO);
            return Ok("Coupon başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDiscountCoupon(string id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Coupon başarıyla silindi");
        }
    }
}
