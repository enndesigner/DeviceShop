using DeviceShop.Domain.Entity;

namespace DeviceShop.Api.Common.Requests
{
    public class UpdateFavouriteRequest
    {
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
