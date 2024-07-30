using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Application.Common.Models
{
    public class UpdateCustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<int>? FavouriteProductIds { get; set; }
    }
}
