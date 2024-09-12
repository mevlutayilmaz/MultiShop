using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CustomerDTO;

namespace MultiShop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var value = _customerService.TGetAll();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            var value = await _customerService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDTO dto)
        {
            await _customerService.TInsertAsync(new()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                District = dto.District,
                City = dto.City,
                Address = dto.Address,
            });
            await _customerService.TSaveAsync();
            return Ok("Müşteri başarılı bir şekilde oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO dto)
        {
            _customerService.TUpdate(new()
            {
                Id = Guid.Parse(dto.Id),
                Name = dto.Name,
                Surname = dto.Surname,
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email
            });
            await _customerService.TSaveAsync();
            return Ok("Müşteri başarılı bir şekilde güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _customerService.TDeleteAsync(id);
            await _customerService.TSaveAsync();
            return Ok("Müşteri başarılı bir şekilde silindi");
        }
    }
}
