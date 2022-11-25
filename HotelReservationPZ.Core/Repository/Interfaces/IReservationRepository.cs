using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Repository
{
    public interface IReservationRepository
    {
        void Delete(Guid id);
        List<Reservation> Get();
        Reservation GetById(Guid id);
        void Insert(Reservation task);
        void Save();
        void Update(Reservation task);
    }
}