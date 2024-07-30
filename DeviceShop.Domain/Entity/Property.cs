namespace DeviceShop.Domain.Entity
{
    public class Property
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public ICollection<ProductProperty>? ProductProperties { get; set; }
    }
}
