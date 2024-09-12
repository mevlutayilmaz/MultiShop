using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoDetailDTO;

namespace MultiShop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService CargoDetailService)
        {
            _cargoDetailService = CargoDetailService;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var value = _cargoDetailService.TGetAll();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailById(string id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDTO dto)
        {
            await _cargoDetailService.TInsertAsync(new()
            {
                Barcode = dto.Barcode,
                CompanyId = Guid.Parse(dto.CompanyId),
                SenderCustomer = dto.SenderCustomer,
                ReceiverCustomer = dto.ReceiverCustomer,
            });
            await _cargoDetailService.TSaveAsync();
            return Ok("Kargo detayları başarılı bir şekilde oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDTO dto)
        {
            _cargoDetailService.TUpdate(new()
            {
                Id = Guid.Parse(dto.Id),
                Barcode = dto.Barcode,
                CompanyId = Guid.Parse(dto.CompanyId),
                SenderCustomer = dto.SenderCustomer,
                ReceiverCustomer = dto.ReceiverCustomer,
            });
            await _cargoDetailService.TSaveAsync();
            return Ok("Kargo detayları başarılı bir şekilde güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(string id)
        {
            await _cargoDetailService.TDeleteAsync(id);
            await _cargoDetailService.TSaveAsync();
            return Ok("Kargo detayları başarılı bir şekilde silindi");
        }
    }
}
