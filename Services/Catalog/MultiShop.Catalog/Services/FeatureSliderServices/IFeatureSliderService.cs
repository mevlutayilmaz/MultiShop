using MultiShop.Catalog.DTOs.FeatureSliderDTOs;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<IList<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDTO> GetByIdFeatureSliderAsync(string id);
    }
}
