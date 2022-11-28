using HotelReservation.EF;
using HotelReservation.Models;

namespace HotelReservation.Core.Repository
{
    public class RoomTypeRepository : BaseRepository<RoomType, HotelDBContext>, IRoomTypeRepository
    {
        #region Constructros

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="context">Context of database</param>
        public RoomTypeRepository(HotelDBContext context) :base(context)
        {

        }

        #endregion

    }
}
