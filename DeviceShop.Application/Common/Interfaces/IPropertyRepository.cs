using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IPropertyRepository
    {
        Task<ICollection<Property>> GetProperties();
        Task<Property> GetPropertyById(int id);
        Task<Property> CreateProperty(Property property);
        Task UpdateProperty(Property property);

        Task DeleteProperty(int propertyId);
    }
}
