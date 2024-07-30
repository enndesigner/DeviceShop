namespace DeviceShop.Application.Common.Models
{
    public class CreatePromocodeModel
    {
        public string PromocodeString { get; set; }

        public int ValuePercent { get; set; }

        public bool IsActive { get; set; }
    }
}
