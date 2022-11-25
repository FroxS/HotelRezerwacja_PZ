using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class GuestService : IGuestService
    {
        private readonly IReservationRepository _reservationRepository;
        public GuestService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public GuestReservationViewModel GetReservation(Guid guid)
        {
            var reservation = _reservationRepository.GetById(guid);

            var vm = new GuestReservationViewModel()
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

    }
}
