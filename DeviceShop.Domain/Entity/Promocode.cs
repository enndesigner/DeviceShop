namespace DeviceShop.Domain.Entity
{
    public class Promocode
    {
        public int Id { get; set; }

        public string PromocodeString { get; set; }

        public int ValuePercent { get; set; }

        public bool IsActive { get; set; }
    }
}
