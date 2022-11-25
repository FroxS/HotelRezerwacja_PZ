using HotelReservation.Core.ViewModels;
using System;

namespace HotelReservation.Core.Service
{
    public interface IGuestService
    {
        GuestReservationViewModel GetReservation(Guid guid);
    }
}