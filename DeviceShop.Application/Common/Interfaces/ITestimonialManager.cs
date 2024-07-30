using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface ITestimonialManager
    {
        Task<ICollection<Testimonial>> GetTestimonials();
        Task<Testimonial> GetTestimonialById(int id);
        
        Task<Testimonial> CreateTestimonial(CreateTestimonialModel testimonial);

        Task UpdateTestimonial(UpdateTestimonialModel testimonial);

        Task DeleteTestimonial(int id);
    }
}
