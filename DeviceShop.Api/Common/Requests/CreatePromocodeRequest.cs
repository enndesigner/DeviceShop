namespace DeviceShop.Api.Common.Requests
{
    public class CreatePromocodeRequest
    {

        public string PromocodeString { get; set; }

        public int ValuePercent { get; set; }

        public bool IsActive { get; set; }
    }
}
