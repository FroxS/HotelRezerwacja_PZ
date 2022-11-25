using HotelReservation.Models;
using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Repository
{
    public interface IHotelCategoryRepository
    {
        void Delete(Guid id);
        List<HotelCategory> Get();
        HotelCategory GetById(Guid id);
        void Insert(HotelCategory task);
        void Save();
        void Update(HotelCategory task);
    }
}