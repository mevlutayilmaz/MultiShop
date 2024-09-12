using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessLayerService(this IServiceCollection service)
        {
            service.AddScoped<ICompanyService, CompanyManager>();
            service.AddScoped<ICustomerService, CustomerManager>();
            service.AddScoped<ICargoDetailService, CargoDetailManager>();
            service.AddScoped<ICargoOperationService, CargoOperationManager>();
        }
    }
}
