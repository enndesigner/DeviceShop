using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IOrderManager
    {
        Task<Order> GetOrderById(int id);
        Task<ICollection<Order>> GetOrders();

        Task<Order> CreateOrder(CreateOrderModel order);

        Task UpdateOrder(UpdateOrderModel order);

        Task DeleteOrder(int orderId);

    }
}
