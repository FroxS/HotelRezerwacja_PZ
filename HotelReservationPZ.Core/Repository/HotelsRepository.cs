using HotelReservation.EF;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Repository
{
    public class HotelsRepository : BaseRepository<Hotel, HotelDBContext>, IHotelsRepository
    {
        #region Constructros

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="context">Context of database</param>
        public HotelsRepository(HotelDBContext context) : base(context)
        {

        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to get all hotels to list included Category, Images and rooms
        /// </summary>
        /// <returns></returns>
        public async override Task<List<Hotel>> GetAllAsync()
        {
            return await context.Hotels
                .Include(h => h.Category)
                .Include(h => h.Images)
                .Include(x => x.Rooms)
                .ToListAsync();
        }

        /// <summary>
        /// Method to get one hotel from databae by Id included Category, Images and rooms
        /// </summary>
        /// <param name="id">Id of this hotel</param>
        /// <returns></returns>
        public async override Task<Hotel> GetByIdAsync(Guid id)
        {
            return await context.Hotels
                .Include(h => h.Category)
                .Include(h => h.Images)
                .Include(x => x.Rooms)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion
    }
}
