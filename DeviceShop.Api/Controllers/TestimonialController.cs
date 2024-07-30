using DeviceShop.Api.Common.Requests;
using DeviceShop.Application.Common.Interfaces;
using DeviceShop.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Api.Controllers
{
    [ApiController]
    [Route("api/testimonial")]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialManager _testimonialManager;

        public TestimonialController(ITestimonialManager orderManager)
        {
            _testimonialManager = orderManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestimonials()
        {
            return Ok(await _testimonialManager.GetTestimonials());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialRequest request)
        {
            CreateTestimonialModel model = new CreateTestimonialModel()
            {
                Content = request.Content,
            };
            return Ok(await _testimonialManager.CreateTestimonial(model));
        }

        //[HttpPost]
    }

}
