using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPromocodeRepository _promocodeRepository;

        public OrderManager(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productManager, IPromocodeRepository promocodeRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productManager;
            _promocodeRepository = promocodeRepository;
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }

        public async Task<Order> GetOrderById(int Id)
        {
            return await _orderRepository.GetOrderById(Id);
        }

        public async Task<Order> CreateOrder(CreateOrderModel order)
        {
            var customer = await _customerRepository.GetCustomerById(order.CustomerId);
            var selectedProducts = await _productRepository.GetProductByIds(order.ProductIds);
            Promocode? promocode = null;

            if (order.PromocodeId.HasValue)
            {
                promocode = await _promocodeRepository.GetPromocodeById(order.PromocodeId.Value);
            }

            var entity = new Order
            {
                DateRequested = order.DateRequested,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                CustomerId = order.CustomerId,
                Customer = customer,
                Products = selectedProducts,
                Promocode = promocode,
                TotalPrice = selectedProducts.Sum(p => p.Price),
                PromocodeId = order.PromocodeId
            };
            return await _orderRepository.CreateOrder(entity);
        }

        public async Task UpdateOrder(UpdateOrderModel order)
        {
            var notUpdatedOrder = await _orderRepository.GetOrderById(order.Id);
            var customer = await _customerRepository.GetCustomerById(notUpdatedOrder.CustomerId);
            var entity = new Order
            {
                Id = order.Id,
                OrderNumb = order.OrderNumb,
                EstimatedDeliveryDate = order.EstimatedDeliveryDate,
                Status = order.Status,
                ShippingDate = order.ShippingDate,
                Customer= customer,
                CustomerId=customer.Id,
                DateRequested=notUpdatedOrder.DateRequested,
                PaymentMethod=notUpdatedOrder.PaymentMethod,
                Products=notUpdatedOrder.Products,
                Promocode=notUpdatedOrder.Promocode,
                PromocodeId=notUpdatedOrder.PromocodeId,
                TotalPrice=notUpdatedOrder.TotalPrice,
            };
            await _orderRepository.UpdateOrder(entity);
        }

        public async Task DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrder(id);
        }

    }
}
