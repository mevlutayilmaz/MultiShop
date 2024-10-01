using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FileServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings, IFileService fileService)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
        {
            var images = await _fileService.UplodProductImagesAsync(createProductImageDTO.Files);
            List<ProductImage> productImages = new();
            foreach (var image in images)
                productImages.Add(new()
                {
                    ProductId = createProductImageDTO.ProductId,
                    ImageUrl = image
                });
            await _productImageCollection.InsertManyAsync(productImages);
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
