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
    public class HotelsController : Controller
    {
        private readonly HotelDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHotelService _service;

        public HotelsController(HotelDBContext context, IHotelService service, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _service = service;
        }

        // GET: Hotels
        public IActionResult Index()
        {
            var hotelDBContext = _context.Hotels.Include(h => h.Category).Include(x => x.Images);
            return View(_service.GetForList());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.HotelCategorys, "Id", "Name");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,City,IsActive,CategoryId,Images")] HotelImageForm hotel)
        {
            if (ModelState.IsValid)
            {
                var hotelEF = new Hotel()
                {
                    Id = Guid.NewGuid(),
                    Name = hotel.Name,
                    Description = hotel.Description,
                    City = hotel.City,
                    IsActive = hotel.IsActive,
                    CategoryId = hotel.CategoryId,
                    Images = new List<HotelImages>()
                };

                if (hotel.Images != null)
                {
                    bool flagIsMain = true;
                    foreach (var form in hotel?.Images)
                    {
                        var path = await UploadFile(form, Path.Combine("Images", "Hotel"));
                        if (!string.IsNullOrEmpty(path))
                        {
                            hotelEF.Images.Add(new HotelImages()
                            {
                                Id = Guid.Parse(Path.GetFileNameWithoutExtension(path)),
                                Extension = Path.GetExtension(path),
                                IsMain = flagIsMain,
                                Path = path,
                                Upload_time = DateTime.Now,
                                Hotel = hotelEF,
                                HotelId = hotelEF.Id
                            });
                            flagIsMain = false;
                        }
                    }
                }
                
                _context.Add(hotelEF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.HotelCategorys, "Id", "Name", hotel.CategoryId);
            return View(hotel);
        }

        private async Task<string> UploadFile(IFormFile form, string path)
        {
            string file = null;

            if(form != null)
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

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.HotelCategorys, "Id", "Name", hotel.CategoryId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,City,IsActive,CategoryId")] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.HotelCategorys, "Id", "Name", hotel.CategoryId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var assingImages = _context.HotelImages.Where(i => i.HotelId == id);

            foreach(var img in assingImages)
            {
                System.IO.File.Delete(Path.Combine(_hostEnvironment.WebRootPath, img.Path));
            }

            _context.HotelImages.RemoveRange(assingImages);

            var hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(Guid id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}
