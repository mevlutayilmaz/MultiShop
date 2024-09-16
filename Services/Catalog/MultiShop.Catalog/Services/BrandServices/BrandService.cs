using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.BrandDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDTO createBrandDTO)
        {
            var value = _mapper.Map<Brand>(createBrandDTO);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(b => b.Id == id);
        }

        public async Task<IList<ResultBrandDTO>> GetAllBrandsAsync()
        {
            var value = await _brandCollection.Find(b => true).ToListAsync();
            return _mapper.Map<IList<ResultBrandDTO>>(value);
        }

        public async Task<GetByIdBrandDTO> GetByIdBrandAsync(string id)
        {
            var value = await _brandCollection.Find(b => b.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDTO>(value);
        }

        public async Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO)
        {
            var value = _mapper.Map<Brand>(updateBrandDTO);
            await _brandCollection.FindOneAndReplaceAsync(b => b.Id == updateBrandDTO.Id, value);
        }
    }
}
