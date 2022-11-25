using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Repository
{
    public interface IHotelsRepository
    {
        void Delete(Guid id);
        List<Hotel> Get();
        Hotel GetById(Guid id);
        void Insert(Hotel task);
        void Save();
        void Update(Hotel task);
    }
}