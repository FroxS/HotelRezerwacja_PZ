using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Service
{
    public interface IRoomService
    {
        Room Create(Room item);
        void Delete(Guid id);
        Room Get(Guid id);
        IEnumerable<Room> GetAll();
        void Update(Guid id, Room item);
        IEnumerable<RoomListViewModel> GetList(Guid hotel, string name);
        IEnumerable<RoomListViewModel> GetList(Guid hotel, string name, DateTime check_in, DateTime check_out);
    }
}