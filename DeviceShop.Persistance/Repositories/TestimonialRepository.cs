using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Domain.Entity;
using DeviceShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Persistance.Repositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly DeviceShopDbContext _context;

        public TestimonialRepository(DeviceShopDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Testimonial>> GetTestimonials()
        {
            return await _context.Testimonials.ToListAsync();
        }

        public async Task<Testimonial> GetTestimonialById(int Id)
        {
            return await _context.Testimonials.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Testimonial> CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
            return testimonial;
        }

        public async Task UpdateTestimonial(Testimonial testimonial)
        {
            var entity = await _context.Testimonials.FirstOrDefaultAsync(i => i.Id == testimonial.Id);
            entity.Content = testimonial.Content;
            entity.Product = testimonial.Product;
            entity.ProductId = testimonial.ProductId;
            entity.CustomerId = testimonial.CustomerId;
            entity.Customer  = testimonial.Customer;

            _context.Testimonials.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTestimonial(int testimonialId)
        {
            var entity = await _context.Testimonials.FirstOrDefaultAsync(i => i.Id == testimonialId);
            _context.Testimonials.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
