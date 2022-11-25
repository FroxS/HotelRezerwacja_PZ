using HotelReservation.EF;
using HotelReservation.Models;

namespace HotelReservation.Core.Repository
{
    public class RoomTypeRepository : BaseRepository<RoomType, HotelDBContext>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelDBContext context) :base(context)
        {

        }
        
    }
}
