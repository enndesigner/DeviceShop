using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [EnableRateLimiting("sliding")]
    [Route("api/product-property")]
    public class ProductPropertyController : ControllerBase
    {
        private readonly IProductPropertyManager _productPropertyManager;

        public ProductPropertyController(IProductPropertyManager productPropertyManager)
        {
            _productPropertyManager = productPropertyManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductProperties()
        {
            return Ok(await _productPropertyManager.GetProductProperties());
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProductPropertyById(int id)
        //{
        //    return Ok(await _productPropertyManager.GetProductPropertyById(id));
        //}

        [HttpPost]
        public async Task<IActionResult> CreateProductProperty(CreateProductPropertyRequest request)
        {
            var productProperty = new CreateProductPropertyModel
            {
                ProductId = request.ProductId,
                PropertyName = request.PropertyName,
                PropertyId = request.PropertyId
            };
            return Ok(await _productPropertyManager.CreateProductProperty(productProperty));
        }

        //[HttpPut]
        //public async Task UpdateProductProperty(UpdateProductPropertyRequest request)
        //{
        //    var updateProductProperty = new UpdateProductPropertyModel
        //    {
        //        ProductId = request.ProductId,
        //        PropertyName = request.PropertyName,
        //        PropertyId = request.PropertyId
        //    };
        //    await _productPropertyManager.UpdateProductProperty(updateProductProperty);
        //}

        //[HttpDelete]
        //public async Task DeleteProductProperty(int id)
        //{
        //    await _productPropertyManager.DeleteProductProperty(id);
        //}
    }

}
