using MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs;

namespace MultiShop.UI.Services.CatalogServices.FeatureSliderServices
{
	public interface IFeatureSliderService
	{
		Task<IList<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync();
		Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO);
		Task DeleteFeatureSliderAsync(string id);
		Task<UpdateFeatureSliderDTO> GetByIdFeatureSliderAsync(string id);
	}
}
