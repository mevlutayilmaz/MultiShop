using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayerService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CargoContext>(option => option.UseSqlServer(configuration.GetConnectionString("MSSQL Server")));

            service.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            service.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
            service.AddScoped<ICustomerDal, EfCustomerDal>();
            service.AddScoped<ICompanyDal, EfCompanyDal>();
        }
    }
}
