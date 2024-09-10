using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            var value = _mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<IList<ResultCategoryDTO>> GetAllCategoriesAsync()
        {
            var value = await _categoryCollection.Find(c => true).ToListAsync();
            return _mapper.Map<IList<ResultCategoryDTO>>(value);
        }

        public async Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDTO>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var value = _mapper.Map<Category>(updateCategoryDTO);
            await _categoryCollection.FindOneAndReplaceAsync(c => c.Id == updateCategoryDTO.Id, value);   
        }
    }
}
