using Dapper;
using Discount.Context;
using DrakeShop.Discount.Dtos;
using System.Reflection.Metadata;

namespace DrakeShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponsAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";

            var parameteres = new DynamicParameters();
            parameteres.Add("@code",createCouponDto.Code);
            parameteres.Add("@rate",createCouponDto.Rate);
            parameteres.Add("@isActive",createCouponDto.IsActive);
            parameteres.Add("@validDate",createCouponDto.ValidDate);

            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameteres);
            }
        }

        public async Task DeleteCouponsAsync(int couponId)
        {
            string query = "delete from Coupons where id = @couponId";

            var parameteres = new DynamicParameters();
            parameteres.Add("@couponId", couponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameteres);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string query = "select * from Coupons";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponsAsync(int couponId)
        {
            string query = "select * from Coupons where CouponId = @couponId";

            var parameteres = new DynamicParameters();
            parameteres.Add("@couponId", couponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameteres);
                return values;
            }
        }

        public async Task UpdateCouponsAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where CouponId=@couponId";

            var parameteres = new DynamicParameters();
            parameteres.Add("@code", updateCouponDto.Code);
            parameteres.Add("@rate", updateCouponDto.Rate);
            parameteres.Add("@isActive", updateCouponDto.IsActive);
            parameteres.Add("@validDate", updateCouponDto.ValidDate);
            parameteres.Add("@couponId", updateCouponDto.CouponId);


            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameteres);
            }
        }
    }
}
