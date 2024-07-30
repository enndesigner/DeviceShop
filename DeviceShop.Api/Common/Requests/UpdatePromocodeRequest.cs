namespace DeviceShop.Api.Common.Requests
{
    public class UpdatePromocodeRequest
    {
        public int Id { get; set; }

        public int ValuePercent { get; set; }

        public bool IsActive { get; set; }
    }
}
