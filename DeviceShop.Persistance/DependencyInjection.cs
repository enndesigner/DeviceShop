using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Persistance.Data;
using DeviceShop.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceShop.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<DeviceShopDbContext>(option=>option.UseNpgsql(configuration.GetConnectionString("MainDb")));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductPropertyRepository, ProductPropertyRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPromocodeRepository, PromocodeRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            return services;
        }

    }
}
