using MultiShop.DTOLayer.CatalogDTOs.BrandDTOs;

namespace MultiShop.UI.Services.CatalogServices.BrandServices
{
	public interface IBrandService
	{
		Task<IList<ResultBrandDTO>> GetAllBrandsAsync();
		Task CreateBrandAsync(CreateBrandDTO createBrandDTO);
		Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO);
		Task DeleteBrandAsync(string id);
		Task<UpdateBrandDTO> GetByIdBrandAsync(string id);
	}
}
