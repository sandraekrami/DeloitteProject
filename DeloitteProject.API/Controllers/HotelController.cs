using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        //[HttpGet("Filter")]
        //[ProducesResponseType(typeof(List<Hotel>), 200)]
        //[ProducesResponseType(typeof(APIResponse<Hotel>), 400)]
        //public async Task<IActionResult> Filter(string keyword, FilterType filterType)
        //{
        //    try
        //    {
        //        var hotels = await serviceResolver(filterType).Apply(keyword);
        //        return Ok(hotels);
        //    }
        //    catch (Exception exp)
        //    {
        //        logger.LogError(exp.Message);
        //        return BadRequest(new APIResponse<Hotel> { Status = false });
        //    }
        //}
    }
}
