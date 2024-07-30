using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IProductPropertyRepository
    {
        Task<ICollection<ProductProperty>> GetProductProperties();


        //Task<ProductProperty> GetProductPropertyById(int productPropertyId);

        Task<ProductProperty> CreateProductProperty(ProductProperty productProperty);
        //Task UpdateProductProperty(ProductProperty productProperty);

        //Task DeleteProductProperty(int productPropertyId);
    }
}
