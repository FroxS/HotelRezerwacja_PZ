using HotelReservation.Core.Repository;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class RoomTypeService : IRoomTypeService
    {
        #region Private Properties

        /// <summary>
        /// Repository of room type
        /// </summary>
        private readonly IRoomTypeRepository _roomTypeRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Deafult constructor
        /// </summary>
        /// <param name="roomTypeRepository">Repository of room typen</param>
        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to get room by id 
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        public async Task<RoomType> GetAsync(Guid id)
        {
            return await _roomTypeRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Method to get all types of room
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoomType>> GetAllAsync()
        {
            return await _roomTypeRepository.GetAllAsync();
        }

        #endregion

    }
}
