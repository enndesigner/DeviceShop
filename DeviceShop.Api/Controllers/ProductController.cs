using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [EnableRateLimiting("sliding")]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productManager.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productManager.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var product = new Application.Common.Dtos.CreateProductModel
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            };
            return Ok(await _productManager.CreateProduct(product));
        }

        [HttpPut]
        public async Task UpdateProduct(UpdateProductRequest request)
        {
            var updateProduct = new UpdateProductModel
            {
                Name = request.Name,
                Description = request.Description,
                Id = request.Id,
                Price = request.Price,

            };
            await _productManager.UpdateProduct(updateProduct);
        }

        [HttpDelete]
        public async Task DeleteProduct(int id)
        {
            await _productManager.DeleteProduct(id);
        }
    }


}
