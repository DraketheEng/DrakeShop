using DrakeShop.Discount.Dtos;
using DrakeShop.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _discountService.GetAllCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById([FromRoute] int id)
        {
            var values = await _discountService.GetByIdCouponsAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponsAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCouponsAsync(id);
            return Ok("Kupon başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponsAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi.");
        }

    }
}
