using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Api.Common.Requests
{
    public class CreateCustomerRequest
    { 
        [Required]
        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
