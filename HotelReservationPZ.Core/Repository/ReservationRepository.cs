using HotelReservation.EF;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Repository
{
    public class ReservationRepository : BaseRepository<Reservation, HotelDBContext>, IReservationRepository
    {
        #region Constructros

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="context">Context of database</param>
        public ReservationRepository(HotelDBContext context) : base(context)
        {

        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to get all eeservation to list included Guest, Rooms, and hotels of rooms
        /// </summary>
        /// <returns></returns>
        public async override Task<List<Reservation>> GetAllAsync()
        {
            return await context.Reservations
                .Include(g => g.Guest)
                .Include(r => r.Rooms)
                .ThenInclude(x => x.Hotlel)
                .ToListAsync();
        }


        /// <summary>
        /// Method to get one reservation from databae by Id included
        /// Guest, Adress of this guest, Rooms, Room images of this rooms and Hotels of this rooms
        /// </summary>
        /// <param name="id">Id of this reservation</param>
        /// <returns></returns>
        public async override Task<Reservation> GetByIdAsync(Guid id)
        {
            return await context.Reservations
                .Include(g => g.Guest)
                .ThenInclude(g => g.Addres)
                .Include(r => r.Rooms)
                .ThenInclude(r => r.RoomImages)
                .Include(r => r.Rooms)
                .ThenInclude(r => r.Hotlel)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

    }
}
