using DeviceShop.Application.Common.Dtos;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IProductPropertyManager
    {
        Task<ICollection<ProductProperty>> GetProductProperties();


        //Task<ProductProperty> GetProductPropertyById(int productPropertyId);

        Task<ProductProperty> CreateProductProperty(CreateProductPropertyModel productProperty);

        //Task UpdateProductProperty(UpdateProductPropertyModel productProperty);

        //Task DeleteProductProperty(int productPropertyId);
    }
}
