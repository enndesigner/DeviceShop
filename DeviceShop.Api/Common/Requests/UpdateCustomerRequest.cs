using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Api.Common.Requests
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string? Email { get; set; }

        public ICollection<int>? FavouriteProductIds { get; set; }

    }
}
