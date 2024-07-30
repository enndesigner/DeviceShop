using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class ProductPropertyManager : IProductPropertyManager
    {
        private readonly IProductPropertyRepository _productPropertyRepository;

        public ProductPropertyManager(IProductPropertyRepository productPropertyRepository)
        {
            _productPropertyRepository = productPropertyRepository;
        }

        public async Task<ICollection<ProductProperty>> GetProductProperties()
        {
            return await _productPropertyRepository.GetProductProperties();
        }

        //public async Task<ProductProperty> GetProductPropertyById(int Id)
        //{
        //    return await _productPropertyRepository.GetProductPropertyById(Id);
        //}

        public async Task<ProductProperty> CreateProductProperty(CreateProductPropertyModel productProperty)
        {
            var entity = new ProductProperty
            {
                ProductId = productProperty.ProductId,
                PropertyName = productProperty.PropertyName,
                PropertyId = productProperty.PropertyId
            };
            return await _productPropertyRepository.CreateProductProperty(entity);
        }

        //public async Task UpdateProductProperty(UpdateProductPropertyModel productProperty)
        //{
        //    var entity = new ProductProperty
        //    {
        //        ProductId = productProperty.ProductId,
        //        PropertyName = productProperty.PropertyName,
        //        PropertyId = productProperty.PropertyId
        //    };
        //    await _productPropertyRepository.UpdateProductProperty(entity);
        //}

        //public async Task DeleteProductProperty(int id)
        //{
        //    await _productPropertyRepository.DeleteProductProperty(id);
        //}
    }
}
