using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public interface IReservationService
    {
        /// <summary>
        /// Method to book reservation
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<Reservation> BookAsync(ReservationFormViewModel form);

        /// <summary>
        /// Method to check if Room is avilable
        /// </summary>
        /// <param name="roomId">Id of room</param>
        /// <param name="check_in">Date of check in</param>
        /// <param name="check_out">Date of check out</param>
        /// <returns></returns>
        Task<bool> IsRooomAvailableAsync(Guid roomId, DateTime check_in, DateTime check_out);

        /// <summary>
        /// Method to check if Room is avilable
        /// </summary>
        /// <param name="roomId">Id of room</param>
        /// <param name="check_in">Date of check in</param>
        /// <param name="check_out">Date of check out</param>
        /// <returns></returns>
        bool IsRooomAvailable(Guid roomId, DateTime check_in, DateTime check_out);

        /// <summary>
        /// Method to take a reservation
        /// </summary>
        /// <param name="id">Id of reservation</param>
        /// <returns></returns>
        Task<Reservation> GetReservation(Guid id);

        Task<List<Reservation>> GetReservations();

        Task<bool> CanelReservation(Guid id);
    }
}