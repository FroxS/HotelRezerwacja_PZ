using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class RoomType
    {
        /// <summary>
        /// Room type id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary> 
        /// Room type name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of rooms - other table
        /// </summary>
        public List<Room> Rooms { get; set; } = new List<Room>();

        public RoomType Clone()
        {
            return new RoomType
            {
                Id = this.Id,
                Name = this.Name,
                Rooms = new List<Room>(this.Rooms)
            };
        }
    }
}
