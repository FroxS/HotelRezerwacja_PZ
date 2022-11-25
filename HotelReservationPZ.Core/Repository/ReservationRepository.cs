using HotelReservation.EF;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.Core.Repository
{
    public class ReservationRepository : BaseRepository<Reservation, HotelDBContext>, IReservationRepository
    {
        public ReservationRepository(HotelDBContext context) :base(context)
        {

        }

        public override List<Reservation> Get()
        {
            return context.Reservations.Include(g => g.Guest).Include(r => r.Rooms).ThenInclude(x => x.Hotlel).ToList();
        }

        public override Reservation GetById(Guid id)
        {
            return context.Reservations
                .Include(g => g.Guest)
                .ThenInclude(g => g.Addres)
                .Include(r => r.Rooms)
                .ThenInclude(r => r.RoomImages)
                .Include(r => r.Rooms)
                .ThenInclude(r => r.Hotlel)
                .FirstOrDefault(x => x.Id == id);
        }

    }
}
