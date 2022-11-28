using HotelReservation.Core.ViewModels;
using System;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public interface IGuestService
    {
        /// <summary>
        /// Method to gel Guest reservation
        /// </summary>
        /// <param name="guid">Id of this reservation</param>
        /// <returns></returns>
        Task<GuestReservationViewModel> GetReservationAsync(Guid guid);
    }
}