using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Api.Common.Requests
{
    public class CreateTestimonialRequest
    {

        public string Content { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
