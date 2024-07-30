using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Domain.Entity
{
    public class Testimonial
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
