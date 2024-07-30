using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetOrders();
        Task<Order> GetOrderById(int id);

        Task<Order> CreateOrder(Order order);
        Task UpdateOrder(Order order);

        Task DeleteOrder(int orderId);

    }
}
