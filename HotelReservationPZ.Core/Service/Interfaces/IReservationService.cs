using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;

namespace HotelReservation.Core.Service
{
    public interface IReservationService
    {
        Reservation Book(ReservationFormViewModel form);
        bool IsRooomAvailable(Guid roomId, DateTime check_in, DateTime check_out);
        Reservation GetReservation(Guid id);
    }
}