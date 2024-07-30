namespace DeviceShop.Api.Common.Requests
{
    public class CreateOrderRequest
    { 
        public string PaymentMethod { get; set; }

        public int CustomerId { get; set; }
        public ICollection<int> SelectedCartProductIds { get; set; }

        public int? PromocodeId { get; set; }

    }
}
