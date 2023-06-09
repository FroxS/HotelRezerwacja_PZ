using HotelReservation.Core.Exeptions;
using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
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

        /// <summary>
        /// Method to create a Room
        /// </summary>
        /// <param name="form">Created room</param>
        /// <param name="wwwpath">Path to savea a image</param>
        /// <returns></returns>
        public async Task<RoomType> CreateAsync(RoomType roomType)
        {

            if (roomType == null) throw new DataExeption("Typ jest pusty");

            if (string.IsNullOrEmpty(roomType.Name)) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.Name), "Brak nazwy typu");

            roomType.Id = roomType.Id == Guid.Empty ? Guid.NewGuid() : roomType.Id;

            await _roomTypeRepository.InsertAsync(roomType);
            await _roomTypeRepository.SaveAsync();
            return roomType;
        }

        /// <summary>
        /// Method to update room
        /// </summary>
        /// <param name="item">Room to update</param>
        /// <returns></returns>
        public async Task UpdateAsync(RoomType item)
        {
            _roomTypeRepository.Update(item);
            await _roomTypeRepository.SaveAsync();
        }

        #endregion

    }
}
