using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoOperationDTO;

namespace MultiShop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService CargoOperationService)
        {
            _cargoOperationService = CargoOperationService;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var value = _cargoOperationService.TGetAll();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationById(string id)
        {
            var value = await _cargoOperationService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDTO dto)
        {
            await _cargoOperationService.TInsertAsync(new()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            });
            await _cargoOperationService.TSaveAsync();
            return Ok("Kargo operasyonu başarılı bir şekilde oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDTO dto)
        {
            _cargoOperationService.TUpdate(new()
            {
                Id = Guid.Parse(dto.Id),
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            });
            await _cargoOperationService.TSaveAsync();
            return Ok("Kargo operasyonu başarılı bir şekilde güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoOperation(string id)
        {
            await _cargoOperationService.TDeleteAsync(id);
            await _cargoOperationService.TSaveAsync();
            return Ok("Kargo operasyonu başarılı bir şekilde silindi");
        }
    }
}
