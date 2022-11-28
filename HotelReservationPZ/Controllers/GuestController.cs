using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservation.EF;
using HotelReservation.Models;
using Microsoft.AspNetCore.Hosting;
using HotelReservation.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using HotelReservation.Core.Service;

namespace HotelReservation.Controllers
{
    public class GuestController : Controller
    {
        #region Private properties

        /// <summary>
        /// Service for guests
        /// </summary>
        private readonly IGuestService _guestService;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="guestService">Service for guest</param>
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        #endregion

        #region Controler actions

        /// <summary>
        /// Deafult action for this controler
        ///  GET: Guest/Index/5
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(Guid reservation)
        {
            var found = await _guestService.GetReservationAsync(reservation);
            if (found == null)
                return NotFound();
            return View(found);
        }

        #endregion
    }
}
