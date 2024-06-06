using DrakeShop.Discount.Dtos;

namespace DrakeShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task CreateCouponsAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponsAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponsAsync(int couponId);
        Task<GetByIdCouponDto> GetByIdCouponsAsync(int couponId);
    }
}
