using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface ICustomerManager
    {
        Task<ICollection<Customer>> GetCustomers();

        Task<Customer> GetCustomerById(int customerId);

        Task<Customer> CreateCustomer(CreateCustomerModel customer);

        Task UpdateCustomer(UpdateCustomerModel customer);

        Task DeleteCustomer(int customerId);
    }
}
