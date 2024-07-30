namespace DeviceShop.Application.Common.Models
{
    public class CreateProductPropertyModel
    {
        public int PropertyId { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }
    }
}
