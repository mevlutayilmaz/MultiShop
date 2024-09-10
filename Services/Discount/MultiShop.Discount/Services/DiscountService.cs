using Dapper;
using MultiShop.Discount.Contexts;
using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO)
        {
            string query = "insert into Coupons (Id, Code, Rate, IsActive, ValidDate) values (@id, @code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@id", Guid.NewGuid());
            parameters.Add("@code", createCouponDTO.Code);
            parameters.Add("@rate", createCouponDTO.Rate);
            parameters.Add("@isActive", createCouponDTO.IsActive);
            parameters.Add("@validDate", createCouponDTO.ValidDate);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(string id)
        {
            string query = "delete from Coupons where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IList<ResultDiscountCouponDTO>> GetAllDiscountCouponsAsync()
        {
            string query = "select * from Coupons";
            using( var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<ResultDiscountCouponDTO>(query);
                return value.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDTO> GetDiscountCouponByIdAsync(string id)
        {
            string query = "select * from Coupons where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDTO>(query,parameters);
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO)
        {
            string query = "update Coupons set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDTO.Code);
            parameters.Add("@rate", updateCouponDTO.Rate);
            parameters.Add("@isActive", updateCouponDTO.IsActive);
            parameters.Add("@validDate", updateCouponDTO.ValidDate);
            parameters.Add("@id", updateCouponDTO.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
