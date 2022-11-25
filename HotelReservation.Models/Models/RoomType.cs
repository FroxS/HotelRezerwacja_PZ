using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class RoomType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
