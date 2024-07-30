namespace DeviceShop.Application.Common.Models
{
    public class UpdateCartModel
    {
        public int Id { get; set; }

        public ICollection<int>? ProductIds { get; set; }

        public int CustomerId { get; set; }
    }
}
