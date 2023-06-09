using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public interface IRoomTypeService
    {
        /// <summary>
        /// Method to get all types of room
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoomType>> GetAllAsync();

        /// <summary>
        /// Method to get room by id 
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        Task<RoomType> GetAsync(Guid id);

        Task<RoomType> CreateAsync(RoomType roomType);
        Task UpdateAsync(RoomType item);
    }
}