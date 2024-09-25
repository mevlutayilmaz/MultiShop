using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CargoDTOs.CompanyDTOs;
using MultiShop.UI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [Route("CargoCompanyList")]
        public async Task<IActionResult> CargoCompanyList()
        {
            CargoViewbagList();
            var values = await _cargoCompanyService.GetAllCargoCompaniesAsync();
            return View(values);
        }

        [Route("CreateCargoCompany")]
        public IActionResult CreateCargoCompany()
        {
            CargoViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDTO);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(string id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(string id)
        {
            CargoViewbagList();
            var values = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDTO);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        void CargoViewbagList()
        {
            ViewBag.h1 = "Home";
            ViewBag.h2 = "Cargos";
            ViewBag.h3 = "Cargo List";
            ViewBag.h0 = "Cargo Operations";
        }
    }
}
