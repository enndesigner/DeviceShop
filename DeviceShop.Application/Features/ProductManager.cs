using DeviceShop.Application.Common.Dtos;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _productRepository.GetProductById(Id);
        }
        public async Task<ICollection<Product>> GetProductByIds(ICollection<int> ids)
        {
            return await _productRepository.GetProductByIds(ids);
        }

        public async Task<Product> CreateProduct(CreateProductModel model)
        {
            var entity = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price= model.Price,
            };
            return await _productRepository.CreateProduct(entity);
        }

        public async Task UpdateProduct(UpdateProductModel product)
        {
            var notUpdatedProduct = await _productRepository.GetProductById(product.Id);

            var entity = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Carts=notUpdatedProduct.Carts,
                CustomersFavourite=notUpdatedProduct.CustomersFavourite,
                Orders = notUpdatedProduct.Orders,
                Price = product.Price,
                ProductProperties = notUpdatedProduct.ProductProperties,
                Testimonials = notUpdatedProduct.Testimonials,
            };
            await _productRepository.UpdateProduct(entity);

        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }
    }
}
