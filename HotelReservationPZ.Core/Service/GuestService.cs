using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class GuestService : IGuestService
    {
        #region Private Properties

        /// <summary>
        /// Repository of reservation
        /// </summary>
        private readonly IReservationRepository _reservationRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Deafult constructor
        /// </summary>
        /// <param name="reservationRepository">Repository of reservation</param>
        public GuestService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to gel Guest reservation
        /// </summary>
        /// <param name="guid">Id of this reservation</param>
        /// <returns></returns>
        public async Task<GuestReservationViewModel> GetReservationAsync(Guid guid)
        {
            Reservation reservation = await _reservationRepository.GetByIdAsync(guid);
            if (reservation == null)
                return null;

            GuestReservationViewModel vm = new GuestReservationViewModel()
            {
                ReservationId = reservation.Id,
                Check_in = reservation.Start_Date,
                Check_out = reservation.End_Date,
                FirstName = reservation.Guest.First_Name,
                LastName = reservation.Guest.Last_Name,
                CountOfRoom = reservation.CountOfRoom,
                CountOfAdults = reservation.CountOfAdults,
                CountOfChildren = reservation.CountOfChildren,
                Country = reservation.Guest.Addres.Country,
                TotalPrice = reservation.Total_Price,
                Street = reservation.Guest.Addres.Street,
                StreetNumber = reservation.Guest.Addres.StreetNumber,
                ZipCode = reservation.Guest.Addres.ZipCode,
                AdditionalInfo = reservation.Details,
                Phone = reservation.Guest.Phone,
                HotelName = reservation.Rooms.FirstOrDefault()?.Hotlel?.Name,
                HoteId = reservation.Rooms.FirstOrDefault()?.HotlelId.ToString()
            };
            return vm;
        }

        #endregion

    }
}
