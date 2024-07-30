using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Features;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IPropertyManager, PropertyManager>();
            services.AddTransient<IProductPropertyManager, ProductPropertyManager>();
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICartManager, CartManager>();
            services.AddTransient<ITestimonialManager, TestimonialManager>();
            services.AddTransient<IPromocodeManager, PromocodeManager>();
            //services.AddTransient<IBussinessLogicManager, MediatorManager>();
            return services;
        }

    }
}
