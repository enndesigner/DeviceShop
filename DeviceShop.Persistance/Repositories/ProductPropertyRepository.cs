using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    public class ProductPropertyRepository : IProductPropertyRepository
    {
        private readonly DeviceShopDbContext _context;

        public ProductPropertyRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ProductProperty>> GetProductProperties()
        {
            return await _context.ProductProperties.ToListAsync();
        }

        //public async Task<ProductProperty> GetProductPropertyById(int Id)
        //{
        //    return await _context.ProductProperties.FirstOrDefaultAsync(p => p.Id == Id);
        //}

        public async Task<ProductProperty> CreateProductProperty(ProductProperty productProperty)
        {
            _context.ProductProperties.Add(productProperty);
            await _context.SaveChangesAsync();
            return productProperty;
        }
        //public async Task UpdateProductProperty(ProductProperty productProperty)
        //{
        //    var entity = await _context.ProductProperties.FirstOrDefaultAsync(i => i.Id == productProperty.Id);
        //    entity.ProductId= productProperty.ProductId;
        //    entity.PropertyId = productProperty.PropertyId;
        //    entity.PropertyName= productProperty.PropertyName;
        //    _context.ProductProperties.Update(entity);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteProductProperty(int id)
        //{
        //    var entity = await _context.ProductProperties.FirstOrDefaultAsync(i => i.Id == id);
        //    _context.ProductProperties.Remove(entity);
        //    await _context.SaveChangesAsync();
        //}

    }
}
