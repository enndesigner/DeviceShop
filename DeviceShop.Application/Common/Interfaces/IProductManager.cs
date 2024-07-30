using DeviceShop.Application.Common.Dtos;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IProductManager
    {
        Task<ICollection<Product>> GetProducts();

        Task<Product> GetProductById(int productId);

        Task<ICollection<Product>> GetProductByIds(ICollection<int> ids);

        Task<Product> CreateProduct(CreateProductModel product);

        Task UpdateProduct(UpdateProductModel product);

        Task DeleteProduct(int productId);
    }
}
