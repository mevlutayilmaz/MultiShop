using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDTO createContactDTO)
        {
            var value = _mapper.Map<Contact>(createContactDTO);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<IList<ResultContactDTO>> GetAllContactsAsync()
        {
            var value = await _contactCollection.Find(c => true).ToListAsync();
            return _mapper.Map<IList<ResultContactDTO>>(value);
        }

        public async Task<GetByIdContactDTO> GetByIdContactAsync(string id)
        {
            var value = await _contactCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDTO>(value);
        }

        public async Task UpdateContactAsync(UpdateContactDTO updateContactDTO)
        {
            var value = _mapper.Map<Contact>(updateContactDTO);
            await _contactCollection.FindOneAndReplaceAsync(c => c.Id == updateContactDTO.Id, value);
        }
    }
}
