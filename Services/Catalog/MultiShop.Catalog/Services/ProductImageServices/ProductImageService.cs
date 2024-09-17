using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDTO);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(pi => pi.Id == id);
        }

        public async Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id)
        {
            var value = await _productImageCollection.Find(pi => pi.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDTO>(value);
        }

        public async Task<IList<GetByIdProductImageDTO>> GetByProductIdProductImageAsync(string productId)
        {
            var value = await _productImageCollection.Find(pi => pi.ProductId == productId).ToListAsync();
            return _mapper.Map<IList<GetByIdProductImageDTO>>(value);
        }

        public async Task<IList<ResultProductImageDTO>> GetProductImagesAsync()
        {
            var value = await _productImageCollection.Find(pi => true).ToListAsync();
            return _mapper.Map<IList<ResultProductImageDTO>>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDTO);
            await _productImageCollection.FindOneAndReplaceAsync(pi => pi.Id == updateProductImageDTO.Id, value);
        }
    }
}
