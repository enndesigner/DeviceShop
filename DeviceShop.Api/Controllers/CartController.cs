using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;

        public CartController(ICartManager productManager)
        {
            _cartManager = productManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            return Ok(await _cartManager.GetCartById(id));
        }

        [HttpPut]
        public async Task UpdateCart(UpdateCartRequest request)
        {
            UpdateCartModel updateCart = new UpdateCartModel { CustomerId=request.CustomerId, Id=request.Id, ProductIds=request.Products };
            await _cartManager.UpdateCart(updateCart);
        }
    }
}
