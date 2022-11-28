using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public interface IRoomService
    {
        /// <summary>
        /// MEthod to create a Room
        /// </summary>
        /// <param name="form">Created room</param>
        /// <param name="wwwpath">Path to savea a image</param>
        /// <returns></returns>
        Task<Room> CreateAsync(RoomImageFormViewModel form, string wwwpath);

        /// <summary>
        /// Method to delete room
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Method to get room by id
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        Task<RoomDetailsViewModel> GetAsync(Guid id);

        /// <summary>
        /// Method to get all rooms
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Room>> GetAllAsync();

        /// <summary>
        /// Method to update room
        /// </summary>
        /// <param name="item">Room to update</param>
        /// <returns></returns>
        Task UpdateAsync(Room item);

        /// <summary>
        /// Method to get filtred list of room
        /// </summary>
        /// <param name="hotel">Id of hotel</param>
        /// <param name="name">Name of room</param>
        /// <returns></returns>
        Task<IEnumerable<RoomListViewModel>> GetListAsync(Guid hotel, string? name);


        /// <summary>
        /// Method to get filtred list of room
        /// </summary>
        /// <param name="hotel">Id of hotel</param>
        /// <param name="name">Name of roo</param>
        /// <param name="check_in">Check in of rervation</param>
        /// <param name="check_out">Check out of rervation</param>
        /// <returns></returns>
        Task<IEnumerable<RoomListViewModel>> GetListAsync(Guid hotel, string name, DateTime check_in, DateTime check_out);
    }
}