using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [EnableRateLimiting("sliding")]
    [Route("api/property")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager _propertyManager;

        public PropertyController(IPropertyManager propertyManager)
        {
            _propertyManager = propertyManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            return Ok(await _propertyManager.GetProperties());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            return Ok(await _propertyManager.GetPropertyById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyRequest request)
        {
            var property = new CreatePropertyModel { Value=request.Value };
            return Ok(await _propertyManager.CreateProperty(property));
        }

        [HttpPut]
        public async Task UpdateProperty(UpdatePropertyRequest request)
        {
            var updateProperty = new UpdatePropertyModel { Id=request.Id, Value=request.Value };
            await _propertyManager.UpdateProperty(updateProperty);
        }

        [HttpDelete]
        public async Task DeleteProperty(int id)
        {
            await _propertyManager.DeleteProperty(id);
        }
    }

}
