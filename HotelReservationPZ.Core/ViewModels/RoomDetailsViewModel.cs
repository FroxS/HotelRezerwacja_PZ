using HotelReservation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HotelReservation.Core.ViewModels
{
    public class RoomDetailsViewModel
    {
        #region Private properties

        /// <summary>
        /// Room
        /// </summary>
        private readonly Room room;

        #endregion

        #region Public propertiess

        /// <summary>
        /// Id of room
        /// </summary>
        public Guid Id => room.Id;

        /// <summary>
        /// Name of room
        /// </summary>
        public string Name => room.Name;

        /// <summary>
        /// Description of room
        /// </summary>
        public string Description => room.Description;

        /// <summary>
        /// Price fo room
        /// </summary>
        public double Price => room.Price;

        /// <summary>
        /// Calculated price with discount
        /// </summary>
        public double DiscountPrice => room.Price * room.Discount;

        /// <summary>
        /// Max quantiny off people in room
        /// </summary>
        public int MaxQuantityOfPeople => room.MaxQuantityOfPeople;

        /// <summary>
        /// Id of hotel
        /// </summary>
        public Guid HotlelId => room.HotlelId;

        /// <summary>
        /// Room type
        /// </summary>
        public string Type => room?.Type?.Name;

        /// <summary>
        /// Room type id
        /// </summary>
        public Guid TypeId => room.TypeId;

        /// <summary>
        /// List of path room image
        /// </summary>
        public List<string> Images => room.RoomImages.Select(room => room.Path).ToList();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="room">Room</param>
        public RoomDetailsViewModel(Room room)
        {
            this.room = room;
        }

        #endregion
    }
}
