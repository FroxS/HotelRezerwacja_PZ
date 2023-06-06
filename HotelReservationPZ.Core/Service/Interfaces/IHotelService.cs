using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public interface IHotelService
    {
        /// <summary>
        /// Method to create hotel
        /// </summary>
        /// <param name="hotel">Created hotel</param>
        /// <param name="imagePath">Path to save images</param>
        /// <returns></returns>
        Task<Hotel> CreateAsync(HotelImageFormViewModel hotel, string imagePath);

        /// <summary>
        /// Method to delete hotel
        /// </summary>
        /// <param name="id">Id of this hotel</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Method to gel one hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Hotel> GetAsync(Guid id);

        Hotel Get(Guid id);

        /// <summary>
        /// Method to gel all hotels to list
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HotelListViewModel>> GetAllVMAsync();

        Task<List<Hotel>> GetAllAsync();

        /// <summary>
        /// Method to update hotel
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Update(Hotel item);

        /// <summary>
        /// Methof to get only hotels
        /// </summary>
        /// <param name="max">Maximim items in list</param>
        /// <returns></returns>
        Task<IEnumerable<Hotel>> GetTopAsync(int max = 3);

        /// <summary>
        /// Method to get list of hotels for home viev 
        /// </summary>
        /// <param name="max">Maximim items in list</param>
        /// <returns></returns>
        Task<IEnumerable<HotelHomeListViewModel>> GetForHomeListAsync(int max = 5);

        /// <summary>
        /// Method to get list of hotels
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HotelListViewModel>> GetForListAsync();

        /// <summary>
        /// Method to get view model of hotel
        /// </summary>
        /// <param name="id">Id of hotel</param>
        /// <returns></returns>
        Task<HotelListViewModel> GetVMAsync(Guid id);
    }
}