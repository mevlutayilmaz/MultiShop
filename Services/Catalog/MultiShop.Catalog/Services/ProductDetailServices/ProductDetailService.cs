using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDTO);
            await _ProductDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _ProductDetailCollection.DeleteOneAsync(pd => pd.Id == id);
        }

        public async Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id)
        {
            var value = await _ProductDetailCollection.Find(pd => pd.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDTO>(value);
        }

        public async Task<IList<ResultProductDetailDTO>> GetProductDetailsAsync()
        {
            var value = await _ProductDetailCollection.Find(pd => true).ToListAsync();
            return _mapper.Map<IList<ResultProductDetailDTO>>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDTO);
            await _ProductDetailCollection.FindOneAndReplaceAsync(pd => pd.Id == updateProductDetailDTO.Id, value);
        }
    }
}
