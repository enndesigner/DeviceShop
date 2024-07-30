namespace DeviceShop.Domain.Entity
{
    public class Order
    {
        public Order()
        {
            TotalPrice = (100 - Promocode.ValuePercent) * Products.Sum(p => p.Price) / 100;
        }
        public int Id { get; set; }
        public string? OrderNumb { get; set; }
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public string PaymentMethod { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; } 
        public ICollection<Product> Products { get; set; }

        public Promocode? Promocode { get; set; }
        public int? PromocodeId { get; set; } 
    }
}
