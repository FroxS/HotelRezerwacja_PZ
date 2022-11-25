using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Repository
{
    public interface IRoomTypeRepository
    {
        void Delete(Guid id);
        List<RoomType> Get();
        RoomType GetById(Guid id);
        void Insert(RoomType task);
        void Save();
        void Update(RoomType task);
    }
}