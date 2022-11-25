using HotelReservation.EF;
using HotelReservation.Models;

namespace HotelReservation.Core.Repository
{
    public class HotelCategoryRepository : BaseRepository<HotelCategory, HotelDBContext>, IHotelCategoryRepository
    {
        public HotelCategoryRepository(HotelDBContext context) :base(context)
        {

        }
        
    }
}
