using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IPromocodeRepository
    {

        Task<Promocode> GetPromocodeById(int id);

        Task<Promocode> CreatePromocode(Promocode promocode);
        Task UpdatePromocode(Promocode promocode);

        Task DeletePromocode(int promocodeId);
    }
}
