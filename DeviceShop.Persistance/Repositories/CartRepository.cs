using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DeviceShopDbContext _context;

        public CartRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartById(int Id)
        {
            return await _context.Carts.FirstOrDefaultAsync(p => p.Id == Id);
        }
        public async Task<Cart> CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

       

        public async Task UpdateCart(Cart cart)
        {
            var entity = await _context.Carts.FirstOrDefaultAsync(i => i.Id == cart.Id);
            entity.Products = cart.Products;
            _context.Carts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCart (int id)
        {
            var entity = await _context.Carts.FirstOrDefaultAsync(i => i.Id == id);
            _context.Carts.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
