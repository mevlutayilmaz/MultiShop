using MultiShop.Image.Services;
using MultiShop.Image.Services.Storage;
using MultiShop.Image.Settings;

namespace MultiShop.Image.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddImageServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStorageService, StorageService>();

            services.Configure<StorageSettings>(configuration.GetSection("Storage"));
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
