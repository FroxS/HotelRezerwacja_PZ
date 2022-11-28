using HotelReservation.EF;
using HotelReservation.Models;

namespace HotelReservation.Core.Repository
{
    public class GuestRepository : BaseRepository<Guest, HotelDBContext>, IGuestRepository
    {
        #region Constructros

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="context">Context of database</param>
        public GuestRepository(HotelDBContext context) :base(context)
        {

        }

        #endregion

    }
}
