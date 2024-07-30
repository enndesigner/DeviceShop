namespace DeviceShop.Api.Common.Requests
{
    public class UpdateOrderRequest
    {
        public int Id { get; set; }
        public string? OrderNumb { get; set; }
        public string Status { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ShippingDate { get; set; }
    }
}
