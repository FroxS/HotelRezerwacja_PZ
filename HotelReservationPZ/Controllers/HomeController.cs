using HotelReservation.Core.Service;
using HotelReservationPZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace HotelReservationPZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _service;

        public HomeController(ILogger<HomeController> logger, IHotelService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            ViewData["HotelsTop3"] = _service.GetTop(3).ToList();
            return View(_service.GetForHomeList());
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
