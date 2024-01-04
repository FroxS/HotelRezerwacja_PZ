using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservation.Core.Service;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservation.Controllers
{
    [Authorize(Roles = "Employee")]
    public class UsersController : Controller
    {
        #region Private Properties

        /// <summary>
        /// Service for users
        /// </summary>
        private readonly IUserService _userService;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Controler actions

        /// <summary>
        /// Default action for this controller
        /// GET: Rooms
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        // GET: Users/Delete/5

        /// <summary>
        /// Action for delete room
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userService.GetAsync(id.Value);
            if (user == null)
                return NotFound();

            return View(user);
        }

        /// <summary>
        /// Action for confirm delete action
        /// POST: Rooms/Delete/5
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
