namespace DeviceShop.Api.Common.Requests
{
    public class CreateProductPropertyRequest
    {
        public int PropertyId { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }
    }
}
