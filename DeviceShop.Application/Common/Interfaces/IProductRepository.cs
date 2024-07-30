using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts();

        Task<Product> GetProductById(int productId);

        Task<ICollection<Product>> GetProductByIds(ICollection<int> ids);

        Task<Product> CreateProduct(Product product);
        Task UpdateProduct (Product product);

        Task DeleteProduct (int productId);
    }
}
