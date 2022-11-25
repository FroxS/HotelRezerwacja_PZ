using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Guest")]
    public class Guest
    {
        [Key]
        public Guid Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Address Addres { get; set; }

        public Guid AddresId { get; set; }

        public Guid ReservationId { get; set; }

        public Reservation Reservation { get; set; }

    }
}
