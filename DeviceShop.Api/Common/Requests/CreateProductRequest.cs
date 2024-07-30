using DeviceShop.Domain.Entity;

namespace DeviceShop.Api.Common.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
