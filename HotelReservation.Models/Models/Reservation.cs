using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        /// <summary>
        /// Reservation id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Reservation check in
        /// </summary>
        public DateTime Start_Date { get; set; }

        /// <summary>
        /// Reservation check out
        /// </summary>
        public DateTime End_Date { get; set; }

        /// <summary>
        /// Reservation total price
        /// </summary>
        public double Total_Price { get; set; }

        /// <summary>
        /// Reservation count of adults
        /// </summary>
        public int CountOfAdults { get; set; }

        /// <summary>
        /// Reservation count of room
        /// </summary>
        public int CountOfRoom { get; set; }

        /// <summary>
        /// Reservation count of children
        /// </summary>
        public int CountOfChildren { get; set; }

        /// <summary>
        /// Reservation details
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Reservation discount
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// List of reservation rooms - other table
        /// </summary>
        public List<Room> Rooms { get; set; }

        /// <summary>
        /// Reservation guest - other table
        /// </summary>
        public Guest Guest { get; set; }

    }
}
