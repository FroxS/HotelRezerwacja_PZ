using System;

namespace HotelReservation.Core.ViewModels
{
    public class RoomListViewModel
    {
        /// <summary>
        /// Id of room
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Room description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Type of room
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Room price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Image of room
        /// </summary>
        public string Image { get; set; }
    }
}
