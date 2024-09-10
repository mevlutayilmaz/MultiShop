using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var value = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<GetByIdProductDTO> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDTO>(value);
        }

        public async Task<IList<ResultProductDTO>> GetProductsAsync()
        {
            var value = await _productCollection.Find(p => true).ToListAsync();
            return _mapper.Map<IList<ResultProductDTO>>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var value = _mapper.Map<Product>(updateProductDTO);
            await _productCollection.FindOneAndReplaceAsync(p => p.Id == updateProductDTO.Id, value);
        }
    }
}
