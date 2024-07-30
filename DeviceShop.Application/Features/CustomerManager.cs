using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;


        public CustomerManager(ICustomerRepository customerRepository, ICartRepository cartRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            return await _customerRepository.GetCustomerById(Id);
        }

        public async Task<Customer> CreateCustomer(CreateCustomerModel customerModel)
        {

            var customer = new Customer
            {
                Name = customerModel.Name,
                PhoneNumber = customerModel.PhoneNumber,
                Email = customerModel.Email,
            };

            await _customerRepository.CreateCustomer(customer);

            var cart = await _cartRepository.CreateCart(new Cart { CustomerId = customer.Id });
            customer.Cart = cart;
            await _customerRepository.UpdateCustomer(customer);
            return customer;
        }

        public async Task UpdateCustomer(UpdateCustomerModel customer)
        {
            var favouriteProducts = await _productRepository.GetProductByIds(customer.FavouriteProductIds);
            var entity = new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Favourites = favouriteProducts
            };
            await _customerRepository.UpdateCustomer(entity);
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            await _cartRepository.DeleteCart(customer.Cart.Id);
            await _customerRepository.DeleteCustomer(id);
        }

    }
}
