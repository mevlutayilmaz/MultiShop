using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.FeatureSliderDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDTO);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(fs => fs.Id == id);
        }

        public async Task<IList<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync()
        {
            var value = await _featureSliderCollection.Find(fs => true).ToListAsync();
            return _mapper.Map<IList<ResultFeatureSliderDTO>>(value);
        }

        public async Task<GetByIdFeatureSliderDTO> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find(fs => fs.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDTO>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDTO);
            await _featureSliderCollection.FindOneAndReplaceAsync(fs => fs.Id == updateFeatureSliderDTO.Id, value);
        }
    }
}
