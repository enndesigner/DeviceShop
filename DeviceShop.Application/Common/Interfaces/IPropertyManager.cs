using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IPropertyManager
    {
        Task<ICollection<Property>> GetProperties();
        Task<Property> GetPropertyById(int id);
        Task<Property> CreateProperty(CreatePropertyModel property);

        Task UpdateProperty(UpdatePropertyModel property);

        Task DeleteProperty(int propertyId);
    }
}
