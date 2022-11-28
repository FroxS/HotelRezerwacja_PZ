using HotelReservation.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationPZ.Controllers
{
    public class HomeController : Controller
    {
        #region Private proprties

        /// <summary>
        /// service for hotel
        /// </summary>
        private readonly IHotelService _hotelService;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="hotelService">Service for hotel</param>
        public HomeController(IHotelService hotelService)
        {
            _hotelService = hotelService; ;
        }

        #endregion

        #region Controler actions

        /// <summary>
        /// Deafult action for this controler
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            ViewData["HotelsTop3"] = (await _hotelService.GetTopAsync(3)).ToList();
            return View(await _hotelService.GetForHomeListAsync());
        }

        #endregion
    }
}
