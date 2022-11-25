using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Repository
{
    public interface IGuestRepository
    {
        void Delete(Guid id);
        List<Guest> Get();
        Guest GetById(Guid id);
        void Insert(Guest task);
        void Save();
        void Update(Guest task);
    }
}