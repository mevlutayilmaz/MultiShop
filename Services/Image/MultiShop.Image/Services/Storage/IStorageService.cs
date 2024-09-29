namespace MultiShop.Image.Services.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
