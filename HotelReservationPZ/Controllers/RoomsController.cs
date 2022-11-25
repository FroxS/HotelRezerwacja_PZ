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
    public class RoomsController : Controller
    {
        private readonly HotelDBContext _context;
        private readonly IRoomService _service;
        private readonly IHotelService _hotelservice;
        private readonly IReservationService _reservationService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RoomsController(
            HotelDBContext context,
            IRoomService service,
            IHotelService hotelservice,
            IWebHostEnvironment hostEnvironment,
            IReservationService reservationService)
        {
            _context = context;
            _service = service;
            _hotelservice = hotelservice;
            _hostEnvironment = hostEnvironment;
            _reservationService = reservationService;
        }

        // GET: Rooms
        public IActionResult Index(Guid hotel, DateTime? check_in, DateTime? check_out, string name)
        {
            ViewData["HotelID"] = hotel;
            ViewData["check_in"] = check_in?.ToString("yyyy-MM-dd") ?? null;
            ViewData["check_out"] = check_out?.ToString("yyyy-MM-dd") ?? null;
            ViewData["name"] = name; 
            if (hotel != Guid.Empty)
            {
                ViewData["Hotel"] = _hotelservice.GetVM(hotel);
            }

            if(check_in != null && check_out != null)
                if(check_in.Value < check_out.Value)
                    return View(_service.GetList(hotel, name, check_in.Value, check_out.Value));
            
            
            return View(_service.GetList(hotel, name));
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hotlel)
                .Include(r => r.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create(Guid hotel)
        {
            ViewData["HotlelId"] = hotel;
            ViewData["TypeId"] = new SelectList(_context.RoomTypes, "Id", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,MaxQuantityOfPeople,TypeId,HotlelId,Images")] RoomImageForm roomFrom)
        {
            Room room = new Room()
            {
                Id = Guid.NewGuid(),
                Name = roomFrom.Name,
                Description = roomFrom.Description,
                MaxQuantityOfPeople = roomFrom.MaxQuantityOfPeople,
                HotlelId = roomFrom.HotlelId,
                TypeId = roomFrom.TypeId,
                Price = roomFrom.Price,
                RoomImages = new List<RoomImages>()
            };
            if (ModelState.IsValid)
            {
                if (roomFrom.Images != null)
                {
                    bool flagIsMain = true;
                    foreach (var form in roomFrom?.Images)
                    {
                        var path = await UploadFile(form, Path.Combine("Images", "Room"));
                        if (!string.IsNullOrEmpty(path))
                        {
                            room.RoomImages.Add(new RoomImages()
                            {
                                Id = Guid.Parse(Path.GetFileNameWithoutExtension(path)),
                                Extension = Path.GetExtension(path),
                                IsMain = flagIsMain,
                                Path = path,
                                Upload_time = DateTime.Now,
                                Room = room,
                                RoomId = room.Id
                            });
                            flagIsMain = false;
                        }
                    }
                }

                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { hotel = roomFrom.HotlelId });
            }
            ViewData["HotlelId"] = new SelectList(_context.Hotels, "Id", "Name", room.HotlelId);
            ViewData["TypeId"] = new SelectList(_context.RoomTypes, "Id", "Name", room.TypeId);
            return View(room);
        }

        private async Task<string> UploadFile(IFormFile form, string path)
        {
            string file = null;

            if (form != null)
            {
                string uploadDir = _hostEnvironment.WebRootPath;
                file = Guid.NewGuid().ToString() + Path.GetExtension(form.FileName);
                file = Path.Combine(path, file);
                using (var fs = new FileStream(Path.Combine(uploadDir, file), FileMode.Create))
                {
                    await form.CopyToAsync(fs);
                }
            }

            return file;
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["HotlelId"] = new SelectList(_context.Hotels, "Id", "Name", room.HotlelId);
            ViewData["TypeId"] = new SelectList(_context.RoomTypes, "Id", "Name", room.TypeId);
            return View(room);
        }

        // GET: Rooms/Reservation/5
        public async Task<IActionResult> Reservation(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }


            List<int> tmplist = new List<int>();
            tmplist.Add(0);
            tmplist.Add(1);
            tmplist.Add(2);
            tmplist.Add(3);
            tmplist.Add(4);
            tmplist.Add(5);
            ViewData["CountOfRooms"] = new SelectList(tmplist,1);
            ViewData["CountOfAdults_list"] = new SelectList(tmplist, 1);
            ViewData["CountOfChildrens"] = new SelectList(tmplist, 0);
            ViewData["Price"] = room.Price;
            ViewBag.RoomId = id;
            ReservationFormViewModel tmp = new ReservationFormViewModel() { RoomPrice = room.Price };

            return View(tmp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reservation(
            [Bind("RoomId,StartDate,EndDate,FirstName,LastName,CountOfRoom,CountOfAdults,CountOfChildren,Country,Street,StreetNumber,ZipCode,City,AdditionalInfo,Email,Phone")]
            ReservationFormViewModel reservationForm)
        {

            ViewBag.RoomId = reservationForm.RoomId;

            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                Reservation res = _reservationService.Book(reservationForm);

                return RedirectToAction(nameof(Index), "Guest", new { reservation = res.Id });
            }
            catch (DataExeption)
            {
                return NotFound();

            }catch(ErrorModelExeption ex)
            {
                foreach(var er in ex.GetData())
                {
                    ModelState.AddModelError(er.Key, er.Value);
                }
                return View();
            }
        }


        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Price,MaxQuantityOfPeople,TypeId,HotlelId")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotlelId"] = new SelectList(_context.Hotels, "Id", "Name", room.HotlelId);
            ViewData["TypeId"] = new SelectList(_context.RoomTypes, "Id", "Name", room.TypeId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hotlel)
                .Include(r => r.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var assingImages = _context.RoomImages.Where(i => i.RoomId == id);

            foreach (var img in assingImages)
            {
                System.IO.File.Delete(Path.Combine(_hostEnvironment.WebRootPath, img.Path));
            }

            _context.RoomImages.RemoveRange(assingImages);

            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(Guid id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
