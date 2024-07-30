using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class TestimonialManager : ITestimonialManager
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public TestimonialManager(ITestimonialRepository testimonialRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _testimonialRepository = testimonialRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<ICollection<Testimonial>> GetTestimonials()
        {
            return await _testimonialRepository.GetTestimonials();
        }

        public async Task<Testimonial> GetTestimonialById(int id)
        {
            return await _testimonialRepository.GetTestimonialById(id);
        }

        public async Task<Testimonial> CreateTestimonial(CreateTestimonialModel testimonial)
        {
            Customer customer = await _customerRepository.GetCustomerById(testimonial.CustomerId);
            Product product = await _productRepository.GetProductById(testimonial.ProductId);
            var entity = new Testimonial
            {
                Content = testimonial.Content,
                CustomerId = testimonial.CustomerId,
                Id = testimonial.ProductId,
                ProductId = testimonial.ProductId,
                Customer= customer,
                Product=product
            };
            return await _testimonialRepository.CreateTestimonial(entity);
        }

        public async Task UpdateTestimonial(UpdateTestimonialModel testimonial)
        {
            var notUpdatedTestimonial = await _testimonialRepository.GetTestimonialById(testimonial.Id);
            var entity = new Testimonial
            {
                Content = testimonial.Content,
                Customer = notUpdatedTestimonial.Customer,
                Id = testimonial.Id,
                CustomerId=notUpdatedTestimonial.CustomerId,
                ProductId=notUpdatedTestimonial.ProductId,
                Product=notUpdatedTestimonial.Product,
            };
            await _testimonialRepository.UpdateTestimonial(entity);
        }

        public async Task DeleteTestimonial(int id)
        {
            await _testimonialRepository.DeleteTestimonial(id);
        }
    }
}
