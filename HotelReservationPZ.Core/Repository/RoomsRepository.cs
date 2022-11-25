using HotelReservation.EF;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.Core.Repository
{
    public class RoomsRepository : BaseRepository<Room, HotelDBContext>, IRoomsRepository
    {
        public RoomsRepository(HotelDBContext context) :base(context)
        {

        }

        public override List<Room> Get()
        {
            return context.Rooms.Include(h => h.Type).Include(h => h.RoomImages).ToList();
        }

    }
}
