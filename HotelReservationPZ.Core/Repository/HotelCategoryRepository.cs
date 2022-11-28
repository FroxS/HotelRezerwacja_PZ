using HotelReservation.EF;
using HotelReservation.Models;

namespace HotelReservation.Core.Repository
{
    public class HotelCategoryRepository : BaseRepository<HotelCategory, HotelDBContext>, IHotelCategoryRepository
    {
        #region Constructros

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="context">Context of database</param>
        public HotelCategoryRepository(HotelDBContext context) :base(context)
        {

        }

        #endregion

    }
}
