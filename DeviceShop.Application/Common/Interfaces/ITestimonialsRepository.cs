using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface ITestimonialRepository
    {
        Task<ICollection<Testimonial>> GetTestimonials();
        Task<Testimonial> GetTestimonialById(int id);
        Task<Testimonial> CreateTestimonial(Testimonial testimonial);
        Task UpdateTestimonial(Testimonial testimonial);

        Task DeleteTestimonial(int testimonialId);
    }
}
