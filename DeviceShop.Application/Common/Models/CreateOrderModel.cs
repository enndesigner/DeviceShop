namespace DeviceShop.Application.Common.Models
{
    public class CreateOrderModel
    {
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
        public string PaymentMethod { get; set; }

        public int CustomerId { get; set; }
        public ICollection<int> ProductIds { get; set; }

        public int? PromocodeId { get; set; }
    }
}
