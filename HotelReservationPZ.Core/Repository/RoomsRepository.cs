using HotelReservation.EF;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Repository
{
    public class RoomsRepository : BaseRepository<Room, HotelDBContext>, IRoomsRepository
    {
        #region Constructros

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="context">Context of database</param>
        public RoomsRepository(HotelDBContext context) :base(context)
        {

        }

        #endregion

        #region Public properties

        /// <summary>
        /// Method to get all Rooms to list included Types and Room images
        /// </summary>
        /// <returns></returns>
        public async override Task<List<Room>> GetAllAsync()
        {
            return await context.Rooms
                .Include(h => h.Type)
                .Include(h => h.RoomImages)
                .Include(h => h.Hotlel)
                .ToListAsync();
        }

        /// <summary>
        /// Method to get all Rooms to list included Types and Room images
        /// </summary>
        /// <returns></returns>
        public async Task<List<Room>> GetAllClearAsync()
        {
            return await context.Rooms.ToListAsync();
        }

        /// <summary>
        /// Method to get one room from databae by Id included Type and Room images 
        /// </summary>
        /// <param name="id">Id of this room</param>
        /// <returns></returns>
        public override async Task<Room> GetByIdAsync(Guid id)
        {
            return await context.Rooms
                .Include(x => x.Type)
                .Include(x => x.RoomImages)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion


    }
}
