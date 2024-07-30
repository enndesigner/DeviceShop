using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface IPromocodeManager
    {

        Task<Promocode> GetPromocodeById(int id);

        Task<Promocode> CreatePromocode(CreatePromocodeModel promocode);

        Task UpdatePromocode(UpdatePromocodeModel promocode);

        Task DeletePromocode(int promocodeId);
    }
}
