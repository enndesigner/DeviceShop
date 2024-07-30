using DeviceShop.Domain.Entity;

namespace DeviceShop.Api.Common.Requests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public ICollection<ProductProperty>? ProductProperties { get; set; }
    }
}
