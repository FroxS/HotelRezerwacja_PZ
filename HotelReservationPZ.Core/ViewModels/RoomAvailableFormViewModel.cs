using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class RoomAvailableFormViewModel
    {
        public Guid RoomId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}
