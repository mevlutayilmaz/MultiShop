using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CompanyDTO;

namespace MultiShop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var value = _companyService.TGetAll();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(string id)
        {
            var value = await _companyService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDTO dto)
        {
            await _companyService.TInsertAsync(new()
            {
                Name = dto.Name,
            });
            await _companyService.TSaveAsync();
            return Ok("Kargo şirketi başarılı bir şekilde oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyDTO dto)
        {
            _companyService.TUpdate(new()
            {
                Id = Guid.Parse(dto.Id),
                Name = dto.Name,
            });
            await _companyService.TSaveAsync();
            return Ok("Kargo şirketi başarılı bir şekilde güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(string id)
        {
            await _companyService.TDeleteAsync(id);
            await _companyService.TSaveAsync();
            return Ok("Kargo şirketi başarılı bir şekilde silindi");
        }
    }
}
