using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.SpecialOfferDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDTO);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(so => so.Id == id);
        }

        public async Task<IList<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync()
        {
            var value = await _specialOfferCollection.Find(so => true).ToListAsync();
            return _mapper.Map<IList<ResultSpecialOfferDTO>>(value);
        }

        public async Task<GetByIdSpecialOfferDTO> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _specialOfferCollection.Find(so => so.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDTO>(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDTO);
            await _specialOfferCollection.FindOneAndReplaceAsync(so => so.Id == updateSpecialOfferDTO.Id, value);
        }
    }
}
