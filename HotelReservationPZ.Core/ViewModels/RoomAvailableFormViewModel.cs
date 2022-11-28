using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class RoomAvailableFormViewModel
    {
        /// <summary>
        /// Id of room
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Room Check in
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Room check out
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

    }
}
