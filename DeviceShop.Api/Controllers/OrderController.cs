using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _orderManager.GetOrders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await _orderManager.GetOrderById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var order = new CreateOrderModel
            {
                PaymentMethod = request.PaymentMethod,
                ProductIds = request.SelectedCartProductIds,
                DateRequested = DateTime.Now,
                CustomerId = request.CustomerId,
                PromocodeId = request.PromocodeId,
                Status = "requested",
            };
            return Ok(await _orderManager.CreateOrder(order));
        }

        [HttpPut]
        public async Task UpdateOrder(UpdateOrderRequest request)
        {
            var updateOrder = new UpdateOrderModel
            {
                Id = request.Id,
                OrderNumb = request.OrderNumb,
                EstimatedDeliveryDate = request.EstimatedDeliveryDate,
                ShippingDate = request.ShippingDate,
                Status = request.Status, 
            };
            await _orderManager.UpdateOrder(updateOrder);
        }

        [HttpDelete]
        public async Task DeleteOrder(int id)
        {
            await _orderManager.DeleteOrder(id);
        }
    }


}