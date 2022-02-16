using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using DeloitteProject.UI.MVC.Models;
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

        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), 200)]
        [ProducesResponseType(typeof(APIResponse<Hotel>), 400)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var hotels = await serviceResolver(FilterType.Name).Apply(string.Empty);
                return Ok(new HotelViewModel { Hotels = hotels, Keyword = string.Empty, Ratings = GetRatings() });
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(new APIResponse<Hotel> { Status = false });
            }
        }

        public async Task<IActionResult> Filter(HotelViewModel model)
        {
            try
            {
                var hotels = await serviceResolver(FilterType.Keyword).Apply(model.Keyword);
                return Ok(new HotelViewModel { Hotels = hotels, Keyword = string.Empty, Ratings = GetRatings() });
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return null;
            }
        }

        private List<int> GetRatings()
        {
            return new List<int> { 1, 2, 3, 4, 5 };
        }
    }
}
