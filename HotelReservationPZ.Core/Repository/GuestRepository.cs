using HotelReservation.EF;
using HotelReservation.Models;

namespace HotelReservation.Core.Repository
{
    public class GuestRepository : BaseRepository<Guest, HotelDBContext>, IGuestRepository
    {
        public GuestRepository(HotelDBContext context) :base(context)
        {

        }
        
    }
}
