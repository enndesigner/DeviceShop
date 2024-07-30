using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CartManager(ICartRepository cartRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }
        public async Task<Cart> GetCartById(int Id)
        {
            return await _cartRepository.GetCartById(Id);
        }

        public async Task<Cart> CreateCart(CreateCartModel cart)
        {
            Customer customer = await _customerRepository.GetCustomerById(cart.CustomerId);
            var entity = new Cart
            {
                CustomerId = cart.CustomerId,
                Customer = customer,
                Products = new List<Product>()
            };
            return await _cartRepository.CreateCart(entity);

        }

        public async Task UpdateCart(UpdateCartModel cart)
        {
            ICollection<Product> products = await _productRepository.GetProductByIds(cart.ProductIds);
            Customer customer = await _customerRepository.GetCustomerById(cart.CustomerId);
            var entity = new Cart {  CustomerId=cart.CustomerId, Customer= customer, Id=cart.Id, Products = products };
            await _cartRepository.UpdateCart(entity);
        }

        public async Task DeleteCart(int id)
        {
            await _cartRepository.DeleteCart(id);
        }
    }
}
