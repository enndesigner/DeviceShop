namespace DeviceShop.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Testimonial>? Testimonials { get; set; }

        public decimal Price { get; set; }

        public ICollection<Cart>? Carts { get; set; }

        public ICollection<Customer>? CustomersFavourite { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public ICollection<ProductProperty>? ProductProperties { get; set; } 

    }
}
