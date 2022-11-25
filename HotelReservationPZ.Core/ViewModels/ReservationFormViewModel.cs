using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class ReservationFormViewModel
    {
        public Guid RoomId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public double RoomPrice { get; set; }

        public string StreetNumber { get; set; }
        public string Street { get; set; }

        public string Country { get; set; }

        public int CountOfRoom { get; set; } = 1;

        public int CountOfChildren { get; set; } = 0;

        public int CountOfAdults { get; set; } = 1;

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        public string AdditionalInfo { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
