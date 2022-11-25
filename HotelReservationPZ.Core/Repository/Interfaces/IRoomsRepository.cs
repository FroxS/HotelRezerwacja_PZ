using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Repository
{
    public interface IRoomsRepository
    {
        void Delete(Guid id);
        List<Room> Get();
        Room GetById(Guid id);
        void Insert(Room task);
        void Save();
        void Update(Room task);
    }
}