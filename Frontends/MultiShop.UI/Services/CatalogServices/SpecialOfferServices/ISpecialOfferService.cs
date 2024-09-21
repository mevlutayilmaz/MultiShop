using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.UI.Services.CatalogServices.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<IList<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync();
		Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO);
		Task DeleteSpecialOfferAsync(string id);
		Task<UpdateSpecialOfferDTO> GetByIdSpecialOfferAsync(string id);
	}
}
