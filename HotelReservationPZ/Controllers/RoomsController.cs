using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Models;
using Microsoft.AspNetCore.Hosting;
using HotelReservation.Core.ViewModels;
using HotelReservation.Core.Service;
using HotelReservation.Core.Exeptions;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace HotelReservation.Controllers
{
    public class RoomsController : Controller
    {
        #region Private Properties

        /// <summary>
        /// Service for rooms
        /// </summary>
        private readonly IRoomService _roomService;

        /// <summary>
        /// Service for hotel
        /// </summary>
        private readonly IHotelService _hotelservice;

        /// <summary>
        /// Service for reservation
        /// </summary>
        private readonly IReservationService _reservationService;

        /// <summary>
        /// Service for room type
        /// </summary>
        private readonly IRoomTypeService _roomTypeService;

        /// <summary>
        /// Host environment
        /// </summary>
        private readonly IWebHostEnvironment _hostEnvironment;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="roomService">Service for rooms</param>
        /// <param name="hotelservice">Service for hotel</param>
        /// <param name="hostEnvironment">Host environment</param>
        /// <param name="reservationService">Service for reservation</param>
        public RoomsController(
            IRoomService roomService,
            IHotelService hotelservice,
            IWebHostEnvironment hostEnvironment,
            IReservationService reservationService,
            IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _hotelservice = hotelservice;
            _hostEnvironment = hostEnvironment;
            _reservationService = reservationService;
            _roomTypeService = roomTypeService;


        }

        #endregion

        #region Controler actions

        /// <summary>
        /// Default action for this controller
        /// GET: Rooms
        /// </summary>
        /// <param name="hotel">Id of hotel</param>
        /// <param name="check_in">Optinal date of check in</param>
        /// <param name="check_out">Optinal date of check out</param>
        /// <param name="name">Optinal search name</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(Guid hotel, DateTime? check_in, DateTime? check_out, string name)
        {
            ViewData["HotelID"] = hotel;
            ViewData["check_in"] = check_in?.ToString("yyyy-MM-dd") ?? null;
            ViewData["check_out"] = check_out?.ToString("yyyy-MM-dd") ?? null;
            ViewData["name"] = name; 
            if (hotel != Guid.Empty)
            {
                ViewData["Hotel"] = await _hotelservice.GetVMAsync(hotel);
            }

            if(check_in != null && check_out != null)
                if(check_in.Value < check_out.Value)
                    return View(await _roomService.GetListAsync(hotel, name, check_in.Value, check_out.Value));
            
            
            return View( await _roomService.GetListAsync(hotel, name));
        }

        /// <summary>
        /// Action for room details
        /// GET: Rooms/Details/5
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                if (id == null) return NotFound();

                return View(await _roomService.GetAsync(id.Value));
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Action for create new room
        ///  GET: Rooms/Create
        /// </summary>
        /// <param name="hotel">Index of hotel</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Guid hotel)
        {

            if ((await _hotelservice.GetAsync(hotel)) == null)
                return NotFound();

            ViewData["HotlelId"] = hotel;
            ViewData["TypeId"] = await getRoomTypeListAsync();
            return View();
        }

        /// <summary>
        ///  Action for create new room from POST method
        ///  POST: Rooms/Create
        /// </summary>
        /// <param name="form">Created room</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,MaxQuantityOfPeople,TypeId,HotlelId,Images")] RoomImageFormViewModel form)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                await _roomService.CreateAsync(form, _hostEnvironment.WebRootPath);

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
                ViewData["TypeId"] = await getRoomTypeListAsync(form.TypeId);
                return View(form);
            }
            
        }

        /// <summary>
        /// Action for edit Room
        /// GET: Rooms/Edit/5
        /// </summary>
        /// <param name="id">Id of this room</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            RoomDetailsViewModel room = await _roomService.GetAsync(id.Value);
            if (room == null)
                return NotFound();

            ViewData["TypeId"] = await getRoomTypeListAsync(room.TypeId);
            ViewData["Hotels"] = new SelectList(await _hotelservice.GetAllAsync(), "Id", "Name");

            return View(room);
        }

        /// <summary>
        /// Action for edit room from POST method
        /// POST: Rooms/Edit/5
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <param name="room">Created room</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Price,MaxQuantityOfPeople,TypeId,HotlelId")] Room room)
        {
            if (id != room.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _roomService.UpdateAsync(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = await getRoomTypeListAsync(room.TypeId);
            return View(room);
        }

        // GET: Rooms/Delete/5

        /// <summary>
        /// Action for delete room
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            RoomDetailsViewModel room = await _roomService.GetAsync(id.Value);
            if (room == null)
                return NotFound();

            return View(room);
        }

        /// <summary>
        /// Action for confirm delete action
        /// POST: Rooms/Delete/5
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _roomService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Action for new reservation
        /// GET: Rooms/Reservation/5
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        public async Task<IActionResult> Reservation(Guid? id)
        {
            if (id == null)
                return NotFound();

            RoomDetailsViewModel room = await _roomService.GetAsync(id.Value);
            if (room == null)
                return NotFound();

            initDataFroReservation();
            
            ViewData["Price"] = room.Price;
            ViewBag.RoomId = id;
            ViewData["RoomImages"] = room.Images;

            IdentityUser user = this?.User?.Identity as IdentityUser;
            ReservationFormViewModel reservation = new ReservationFormViewModel();
            if(user != null)
            {
                reservation.FirstName = user.UserName;
                reservation.Email = user.Email;
                reservation.Phone= user.PhoneNumber;
            }
            return View(reservation);
        }

        /// <summary>
        /// Action for new reservation from POST method
        /// </summary>
        /// <param name="reservationForm">Created reservation</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservation(
            [Bind("RoomId,StartDate,EndDate,FirstName,LastName,CountOfRoom,CountOfAdults,CountOfChildren,Country,Street,StreetNumber,ZipCode,City,AdditionalInfo,Email,Phone")]
            ReservationFormViewModel reservationForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    initDataFroReservation();
                    ViewData["Price"] = (await _roomService.GetAsync(reservationForm.RoomId)).Price;
                    ViewBag.RoomId = reservationForm.RoomId;
                    ViewData["RoomImages"] = (await _roomService.GetAsync(reservationForm.RoomId)).Images;
                    return View();
                }
                Reservation res = await _reservationService.BookAsync(reservationForm);

                return RedirectToAction("Index", "Guest", new { reservation = res.Id });
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
                initDataFroReservation();
                ViewData["Price"] = (await _roomService.GetAsync(reservationForm.RoomId)).Price;
                ViewBag.RoomId = reservationForm.RoomId;
                ViewData["RoomImages"] = (await _roomService.GetAsync(reservationForm.RoomId)).Images;
                return View();
            }
        }

        #endregion

        #region Private helpers

        /// <summary>
        /// Method to init data in view for reservation 
        /// </summary>
        private void initDataFroReservation()
        {
            List<int> tmplist = new List<int>();
            tmplist.Add(0);
            tmplist.Add(1);
            tmplist.Add(2);
            tmplist.Add(3);
            tmplist.Add(4);
            tmplist.Add(5);
            ViewData["CountOfRooms"] = new SelectList(tmplist, 1);
            ViewData["CountOfAdults_list"] = new SelectList(tmplist, 1);
            ViewData["CountOfChildrens"] = new SelectList(tmplist, 0);
        }

        /// <summary>
        /// method to get list to select in view of category
        /// </summary>
        /// <param name="selectedCategory">Optional default select value</param>
        /// <returns></returns>
        private async Task<SelectList> getRoomTypeListAsync(Guid? selectedCategory = null)
        {
            if (selectedCategory != null)
                return new SelectList(await _roomTypeService.GetAllAsync(), "Id", "Name", selectedCategory);
            else
                return new SelectList(await _roomTypeService.GetAllAsync(), "Id", "Name");
        }



        #endregion

    }
}
