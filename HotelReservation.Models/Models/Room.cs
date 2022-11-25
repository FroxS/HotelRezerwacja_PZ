using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; } = 1.0;

        public int MaxQuantityOfPeople { get; set; }

        public Guid TypeId { get; set; }

        public RoomType Type { get; set; }

        public Guid HotlelId { get; set; }

        public Hotel Hotlel { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<RoomImages> RoomImages { get; set; } = new List<RoomImages>();
        public RoomImages MainImage => RoomImages?.Find(x => x.IsMain);

    }
}
