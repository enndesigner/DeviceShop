using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DeviceShopDbContext _context;

        public OrderRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            return await _context.Orders
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int Id)
        {
            return await _context.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }


        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task UpdateOrder(Order order)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(i => i.Id == order.Id);
            entity.DateRequested = order.DateRequested;
            entity.ShippingDate = order.ShippingDate;
            entity.Status = order.Status;
            entity.CustomerId = order.CustomerId;
            entity.OrderNumb = order.OrderNumb;
            entity.PaymentMethod = order.PaymentMethod;
            entity.Products = order.Products;
            entity.Customer = order.Customer;
            entity.CustomerId = order.CustomerId;
            entity.Promocode = order.Promocode;
            entity.PromocodeId = order.PromocodeId;
            entity.EstimatedDeliveryDate = order.EstimatedDeliveryDate;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(i => i.Id == id);
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
