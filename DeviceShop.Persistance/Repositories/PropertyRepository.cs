using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    internal class PropertyRepository : IPropertyRepository
    {
        private readonly DeviceShopDbContext _context;

        public PropertyRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Property>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property> GetPropertyById(int Id)
        {
            return await _context.Properties.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Property> CreateProperty(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }
        public async Task UpdateProperty(Property property)
        {
            var entity = await _context.Properties.FirstOrDefaultAsync(i => i.Id == property.Id);
            entity.Value = property.Value;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProperty(int id)
        {
            var entity = await _context.Properties.FirstOrDefaultAsync(i => i.Id == id);
            _context.Properties.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
