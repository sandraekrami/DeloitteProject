using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeloitteProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly Func<FilterType, IFilterService> serviceResolver;
        private readonly ILogger<HotelController> logger;

        public HotelController(Func<FilterType, IFilterService> serviceResolver, 
            ILogger<HotelController> logger)
        {
            this.serviceResolver = serviceResolver;
            this.logger = logger;
        }

        [HttpGet("GetAllHotels")]
        [ProducesResponseType(typeof(List<Hotel>), 200)]
        [ProducesResponseType(typeof(APIResponse<Hotel>), 400)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var hotels = await serviceResolver(FilterType.Name).Apply(string.Empty);
                return Ok(hotels);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(new APIResponse<Hotel> { Status = false });
            }
        }
    }
}
