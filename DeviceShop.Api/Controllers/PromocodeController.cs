using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [EnableRateLimiting("sliding")]
    [Route("api/promocode")]
    public class PromocodeController : ControllerBase
    {
        private readonly IPromocodeManager _promocodeManager;

        public PromocodeController(IPromocodeManager promocodeManager)
        {
            _promocodeManager = promocodeManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromocodeById(int id)
        {
            return Ok(await _promocodeManager.GetPromocodeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromocode(CreatePromocodeRequest request)
        {
            var promocode = new CreatePromocodeModel
            {
                PromocodeString = request.PromocodeString,
                ValuePercent=request.ValuePercent,
                IsActive=request.IsActive,
            };
            return Ok(await _promocodeManager.CreatePromocode(promocode));
        }

        [HttpPut]
        public async Task UpdatePromocode(UpdatePromocodeRequest request)
        {
            var updatePromocode = new UpdatePromocodeModel
            {
                Id = request.Id,
                IsActive = request.IsActive,
                ValuePercent = request.ValuePercent,
            };
            await _promocodeManager.UpdatePromocode(updatePromocode);
        }

        [HttpDelete]
        public async Task DeletePromocode(int id)
        {
            await _promocodeManager.DeletePromocode(id);
        }
    }

}
