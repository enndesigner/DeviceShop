using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Features
{
    public class PromocodeManager : IPromocodeManager
    {
        private readonly IPromocodeRepository _promocodeRepository;

        public PromocodeManager(IPromocodeRepository promocodeRepository)
        {
            _promocodeRepository = promocodeRepository;
        }

        public async Task<Promocode> GetPromocodeById(int id)
        {
            return await _promocodeRepository.GetPromocodeById(id);
        }

        public async Task<Promocode> CreatePromocode(CreatePromocodeModel promocode)
        {
            var entity = new Promocode
            {
                PromocodeString = promocode.PromocodeString,
                IsActive = promocode.IsActive,
                ValuePercent = promocode.ValuePercent,
            };
            return await _promocodeRepository.CreatePromocode(entity);
        }

        public async Task UpdatePromocode(UpdatePromocodeModel promocode)
        {
            var notUpdatedPromocode = await _promocodeRepository.GetPromocodeById(promocode.Id);
            var entity = new Promocode
            {
                Id = promocode.Id,
                IsActive = promocode.IsActive,
                PromocodeString = notUpdatedPromocode.PromocodeString,
                ValuePercent=promocode.ValuePercent,

            };
            await _promocodeRepository.UpdatePromocode(entity);
        }

        public async Task DeletePromocode(int id)
        {
            await _promocodeRepository.DeletePromocode(id);
        }
    }
}
