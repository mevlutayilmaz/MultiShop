using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Persistence.Contexts;
using MultiShop.Order.Persistence.Repositories;

namespace MultiShop.Order.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<OrderContext>(option => option.UseSqlServer(configuration.GetConnectionString("MSSQL Server")));

            service.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            service.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }
    }
}
