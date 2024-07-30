using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class PropertyManager : IPropertyManager
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyManager(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<ICollection<Property>> GetProperties()
        {
            return await _propertyRepository.GetProperties();
        }

        public async Task<Property> GetPropertyById(int id)
        {
            return await _propertyRepository.GetPropertyById(id);
        }
        public async Task<Property> CreateProperty(CreatePropertyModel property)
        {
            var entity = new Property { Value=property.Value };
            return await _propertyRepository.CreateProperty(entity);
        }

        public async Task UpdateProperty(UpdatePropertyModel property)
        {

            var entity = new Property { Value = property.Value, Id=property.Id };
            await _propertyRepository.UpdateProperty(entity);

        }

        public async Task DeleteProperty(int id)
        {
            await _propertyRepository.DeleteProperty(id);
        }
    }
}
