using MultiShop.Catalog.DTOs.OfferDiscountDTOs;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<IList<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO);
        Task DeleteOfferDiscountAsync(string id);
        Task<GetByIdOfferDiscountDTO> GetByIdOfferDiscountAsync(string id);
    }
}
