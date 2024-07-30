using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Application.Common.Models
{
    public class CreateCustomerModel
    {

        [Required]
        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }


    }
}
