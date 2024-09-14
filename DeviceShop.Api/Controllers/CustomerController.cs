using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.RateLimiting;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [EnableRateLimiting("sliding")]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _customerManager.GetCustomers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await _customerManager.GetCustomerById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            CreateCustomerModel customer = new CreateCustomerModel
            {
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Name = request.Name
            };

            var customerCreated = await _customerManager.CreateCustomer(customer);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            
            var json = JsonSerializer.Serialize(customerCreated, options);
            return Ok(json);
        }

        [HttpPut]
        public async Task UpdateCustomer(UpdateCustomerRequest request)
        {
            var customer = new UpdateCustomerModel
            {
                Id = request.Id,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Name = request.Name, 
                FavouriteProductIds = request.FavouriteProductIds
            };
            await _customerManager.UpdateCustomer(customer);
        }

        [HttpDelete]
        public async Task DeleteCustomer(int id)
        {
            await _customerManager.DeleteCustomer(id);
        }
    }
}
