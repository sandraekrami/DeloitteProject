using DeloitteProject.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeloitteProject.UI.TS.Controllers
{
    [Controller]
    public class HotelController : Controller
    {
        private readonly ISearchHotelsService getAllHotelsService;
        private readonly ILogger<HomeController> logger;

        public HotelController(ISearchHotelsService getAllHotelsService, ILogger<HomeController> logger)
        {
            this.getAllHotelsService = getAllHotelsService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            var hotels = getAllHotelsService.GetAllAsync().Result.ToList();

            return View(hotels);
        }
    }
}
