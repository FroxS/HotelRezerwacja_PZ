using HotelReservation.Core.Exeptions;
using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class HotelCategoryService : IHotelCategoryService
    {
        #region Private Properties

        /// <summary>
        /// Repository of hotel category
        /// </summary>
        private readonly IHotelCategoryRepository _hotelCategoryRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="hotelCategoryRepository">Repository of hotel category</param>
        public HotelCategoryService(IHotelCategoryRepository hotelCategoryRepository)
        {
            _hotelCategoryRepository = hotelCategoryRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to get one category of hotel from all in database
        /// </summary>
        /// <param name="id">Id of this category</param>
        /// <returns></returns>
        public async Task<HotelCategory> GetAsync(Guid id)
        {
            return await _hotelCategoryRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Method to get all category of hotel
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HotelCategory>> GetAllAsync()
        {
            return await _hotelCategoryRepository.GetAllAsync();
        }

        #endregion

    }
}
