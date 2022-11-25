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
using HotelReservation.Core.Exeptions;

namespace HotelReservation.Controllers
{
    public class GuestController : Controller
    {
        private readonly HotelDBContext _context;
        private readonly IGuestService _guestService;

        public GuestController(
            HotelDBContext context,
            IGuestService guestService)
        {
            _context = context;
            _guestService = guestService;
        }

        // GET: Guest/Index/5
        public IActionResult Index(Guid reservation)
        {
            
            var found = _guestService.GetReservation(reservation);
            if (found == null)
                return NotFound();
            return View(found);
        }
    }
}
