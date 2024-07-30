namespace DeviceShop.Api.Common.Requests
{
    public class UpdateCartRequest
    {
        public int Id { get; set; }

        public ICollection<int>? Products { get; set; }

        public int CustomerId { get; set; }

    }
}
