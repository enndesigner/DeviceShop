namespace DeviceShop.Application.Common.Models
{
    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public string? OrderNumb { get; set; }
        public string Status { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ShippingDate { get; set; }
    }
}
