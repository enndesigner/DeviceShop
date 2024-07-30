using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DeviceShopDbContext _context;

        public ProductRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            
        }

        public async Task<ICollection<Product>> GetProductByIds(ICollection<int> productIds)
        {
            return await _context.Products
                                 .Where(p => productIds.Contains(p.Id))
                                 .ToListAsync();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product; 
        }
        public async Task UpdateProduct(Product product)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(i => i.Id == product.Id); 
            entity.Testimonials=product.Testimonials; 
            entity.Price=product.Price;
            entity.Carts=product.Carts;
            entity.Orders=product.Orders;
            entity.CustomersFavourite=product.CustomersFavourite;
            entity.Description=product.Description;
            entity.Name=product.Name;
            entity.ProductProperties=product.ProductProperties;

            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(i=>i.Id==id);
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
