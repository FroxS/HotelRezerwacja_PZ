using HotelReservation.EF;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.Core.Repository
{
    public class HotelsRepository :BaseRepository<Hotel, HotelDBContext>, IHotelsRepository
    {
        public HotelsRepository(HotelDBContext context):base(context)
        {

        }

        public override List<Hotel> Get()
        {
            return context.Hotels
                .Include(h => h.Category)
                .Include(h => h.Images)
                .Include(x => x.Rooms)
                .ToList();
        }

        public override Hotel GetById(Guid id)
        {
            return context.Hotels
                .Include(h => h.Category)
                .Include(h => h.Images)
                .Include(x => x.Rooms)
                .ToList()
                .Find(x => x.Id == id);
        }
    }
}
