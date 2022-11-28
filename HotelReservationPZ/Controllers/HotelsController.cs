using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Models;
using Microsoft.AspNetCore.Hosting;
using HotelReservation.Core.ViewModels;
using HotelReservation.Core.Service;
using HotelReservation.Core.Exeptions;

namespace HotelReservation.Controllers
{
    public class HotelsController : Controller
    {
        #region Private Properties

        /// <summary>
        /// Host environment
        /// </summary>
        private readonly IWebHostEnvironment _hostEnvironment;

        /// <summary>
        /// Service for hotel
        /// </summary>
        private readonly IHotelService _hotelService;

        /// <summary>
        /// Service for category of hotel
        /// </summary>
        private readonly IHotelCategoryService _hotelCategoryService;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="hotelService">Service for hotel</param>
        /// <param name="hostEnvironment">Host environment</param>
        public HotelsController(IHotelService hotelService, IHotelCategoryService hotelCategoryService, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _hotelService = hotelService;
            _hotelCategoryService = hotelCategoryService;
        }

        #endregion

        #region Controler actions

        /// <summary>
        /// Default action for this controller
        /// GET: Hotels
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllAsync());
        }

        /// <summary>
        /// Action for hotel details
        /// GET: Hotels/Details/5
        /// </summary>
        /// <param name="id">Index of this hotel</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var hotel = await _hotelService.GetAsync(id.Value);

            if (hotel == null) return NotFound();

            return View(hotel);
        }

        /// <summary>
        /// Action for create new hotel
        /// GET: Hotels/Create
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = await getHootelCategoryListAsync();
            return View();
        }

        /// <summary>
        /// Action for create new hotel from POST method
        /// POST: Hotels/Create
        /// </summary>
        /// <param name="hotel">Created hotel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,City,IsActive,CategoryId,Images")] HotelImageFormViewModel hotel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                await _hotelService.CreateAsync(hotel, _hostEnvironment.WebRootPath);

                return RedirectToAction(nameof(Index));
            }
            catch (DataExeption)
            {
                return NotFound();
            }
            catch (ErrorModelExeption ex)
            {
                foreach (var er in ex.GetData())
                {
                    ModelState.AddModelError(er.Key, er.Value);
                }
                ViewData["CategoryId"] = await getHootelCategoryListAsync(hotel.CategoryId);
                return View();
            }
        }

        /// <summary>
        /// Action for edit Hotel
        /// GET: Hotels/Edit/5
        /// </summary>
        /// <param name="id">Id of this hotel</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var hotel = await _hotelService.GetAsync(id.Value);
            if (hotel == null) return NotFound(); 
            ViewData["CategoryId"] = await getHootelCategoryListAsync(hotel.CategoryId);
            return View(hotel);
        }

        /// <summary>
        /// Action for edit Hotel 
        /// POST: Hotels/Edit/5
        /// </summary>
        /// <param name="id">Id of this hotel</param>
        /// <param name="hotel">Edited hotel form post form</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,City,IsActive,CategoryId")] Hotel hotel)
        {
            if (id != hotel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotelService.Update(hotel);
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = await getHootelCategoryListAsync(hotel.CategoryId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5

        /// <summary>
        /// Action for delete Hotel
        /// </summary>
        /// <param name="id">Id of this hotel</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            Hotel hotel = await _hotelService.GetAsync(id.Value);
            if (hotel == null) return NotFound();

            return View(hotel);
        }

        /// <summary>
        /// Action for delete Hotel from POST methos
        /// POST: Hotels/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _hotelService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// method to get list to select in view of category
        /// </summary>
        /// <param name="selectedCategory">Optional default select value</param>
        /// <returns></returns>
        private async Task<SelectList> getHootelCategoryListAsync(Guid? selectedCategory = null)
        {
            if(selectedCategory != null)
                return new SelectList(await _hotelCategoryService.GetAllAsync(), "Id", "Name", selectedCategory);
            else
                return new SelectList(await _hotelCategoryService.GetAllAsync(), "Id", "Name");
        }

        #endregion
    }
}
