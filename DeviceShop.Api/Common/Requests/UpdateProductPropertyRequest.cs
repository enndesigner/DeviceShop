namespace DeviceShop.Api.Common.Requests
{
    public class UpdateProductPropertyRequest
    {
        public int PropertyId { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }
    }
}
