using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Application.Common.Models
{
    public class CreateTestimonialModel
    {
        public string Content { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
