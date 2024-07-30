using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DeviceShopDbContext _context;

        public CustomerRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            return await _context.Customers.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(i => i.Id == customer.Id);
            entity.Favourites = customer.Favourites;
            entity.Cart = customer.Cart;
            entity.PhoneNumber = customer.PhoneNumber;
            entity.Name = customer.Name;
            entity.Email = customer.Email;
            entity.Orders = customer.Orders;
            entity.PhoneNumber = customer.PhoneNumber;
            entity.Name = customer.Name;
            entity.Email = customer.Email;
            

            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(i => i.Id == id);
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
