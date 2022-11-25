using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Service
{
    public interface IHotelService
    {
        Hotel Create(Hotel item);
        void Delete(Guid id);
        Hotel Get(Guid id);
        IEnumerable<Hotel> GetAll();
        void Update(Guid id, Hotel item);
        IEnumerable<Hotel> GetTop(int max = 3);
        IEnumerable<HotelHomeListViewModel> GetForHomeList(int max = 5);
        IEnumerable<HotelListViewModel> GetForList();
        HotelListViewModel GetVM(Guid id);
    }
}