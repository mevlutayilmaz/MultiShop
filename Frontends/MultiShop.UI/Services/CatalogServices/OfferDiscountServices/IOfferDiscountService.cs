using MultiShop.DTOLayer.CatalogDTOs.OfferDiscountDTOs;

namespace MultiShop.UI.Services.CatalogServices.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<IList<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync();
		Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO);
		Task DeleteOfferDiscountAsync(string id);
		Task<UpdateOfferDiscountDTO> GetByIdOfferDiscountAsync(string id);
	}
}
