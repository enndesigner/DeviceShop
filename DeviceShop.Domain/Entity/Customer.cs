using System.ComponentModel.DataAnnotations;

namespace DeviceShop.Domain.Entity
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public Cart? Cart { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public ICollection<Product>? Favourites { get; set; }
    }
}
