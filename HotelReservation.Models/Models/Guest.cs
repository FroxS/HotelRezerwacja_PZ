using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Guest")]
    public class Guest
    {
        /// <summary>
        /// Guest id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Guest first name
        /// </summary>
        public string First_Name { get; set; }

        // <summary>
        /// Guest last name
        /// </summary>
        public string Last_Name { get; set; }

        // <summary>
        /// Guest email
        /// </summary>
        public string Email { get; set; }

        // <summary>
        /// Guest phone
        /// </summary>
        public string Phone { get; set; }

        // <summary>
        /// Guest addres - other table
        /// </summary>
        public Address Addres { get; set; }

        // <summary>
        /// Guest addresId - foregin key
        /// </summary>
        public Guid AddresId { get; set; }

        // <summary>
        /// Guest reservationId - foregin key
        /// </summary>
        public Guid ReservationId { get; set; }

        // <summary>
        /// Guest reservation - other table
        /// </summary>
        public Reservation Reservation { get; set; }

    }
}
