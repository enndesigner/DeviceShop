namespace DeviceShop.Application.Common.Models
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
