using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public bool IsActive { get; set; }

        public int HoursCheckOutFrom { get; set; }

        public int HoursCheckOutTo{ get; set; }

        public int HoursCheckInFrom { get; set; }

        public int HoursCheckInTo { get; set; }

        public Guid CategoryId { get; set; }

        public HotelCategory Category { get; set; }

        public List<Room> Rooms { get; set; }

        public List<HotelImages> Images { get; set; } = new List<HotelImages>();

        public HotelImages MainImage => Images?.Find(x => x.IsMain);

    }
}
