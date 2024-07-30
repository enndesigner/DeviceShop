using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(int customerId);
    }
}
