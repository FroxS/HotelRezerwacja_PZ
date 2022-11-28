using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public interface IHotelCategoryService
    {
        /// <summary>
        /// Method to get all category of hotel
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HotelCategory>> GetAllAsync();

        /// <summary>
        /// Method to get one category of hotel from all in database
        /// </summary>
        /// <param name="id">Id of this category</param>
        /// <returns></returns>
        Task<HotelCategory> GetAsync(Guid id);
    }
}