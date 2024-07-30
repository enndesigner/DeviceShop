namespace DeviceShop.Domain.Entity
{
    public class Cart
    {
        public int Id { get; set; }

        public ICollection<Product>? Products { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
