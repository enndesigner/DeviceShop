using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    public class PromocodeRepository : IPromocodeRepository
    {
        private readonly DeviceShopDbContext _context;

        public PromocodeRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<Promocode> GetPromocodeById(int Id)
        {
            return await _context.Promocodes.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Promocode> CreatePromocode(Promocode promocode)
        {
            _context.Promocodes.Add(promocode);
            await _context.SaveChangesAsync();
            return promocode;
        }
        public async Task UpdatePromocode(Promocode promocode)
        {
            var entity = await _context.Promocodes.FirstOrDefaultAsync(i => i.Id == promocode.Id);
            entity.ValuePercent = promocode.ValuePercent;
            entity.PromocodeString  = promocode.PromocodeString;
            entity.IsActive = promocode.IsActive;
            _context.Promocodes.Update(entity);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeletePromocode(int id)
        {
            var entity = await _context.Promocodes.FirstOrDefaultAsync(i => i.Id == id);
            _context.Promocodes.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
