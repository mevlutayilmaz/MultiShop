using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.OfferDiscountDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDTO);
            await _offerDiscountCollection.InsertOneAsync(value);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(od => od.Id == id);
        }

        public async Task<IList<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync()
        {
            var value = await _offerDiscountCollection.Find(od => true).ToListAsync();
            return _mapper.Map<IList<ResultOfferDiscountDTO>>(value);
        }

        public async Task<GetByIdOfferDiscountDTO> GetByIdOfferDiscountAsync(string id)
        {
            var value = await _offerDiscountCollection.Find(od => od.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDTO>(value);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDTO);
            await _offerDiscountCollection.FindOneAndReplaceAsync(od => od.Id == updateOfferDiscountDTO.Id, value);
        }
    }
}
