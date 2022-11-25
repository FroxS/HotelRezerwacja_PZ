using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public double Total_Price { get; set; }

        public int CountOfAdults { get; set; }

        public int CountOfRoom { get; set; }

        public int CountOfChildren { get; set; }

        public string Details { get; set; }

        public double Discount { get; set; }

        public List<Room> Rooms { get; set; }

        public Guest Guest { get; set; }

    }
}
