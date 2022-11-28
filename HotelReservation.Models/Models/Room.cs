using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Room")]
    public class Room
    {
        /// <summary>
        /// Room id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Room name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Room description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Room price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Room discount
        /// </summary>
        public double Discount { get; set; } = 1.0;

        /// <summary>
        /// Room max quantity of people
        /// </summary>
        public int MaxQuantityOfPeople { get; set; }

        /// <summary>
        /// Room typeId - foregin key
        /// </summary>
        public Guid TypeId { get; set; }

        /// <summary>
        /// Room type - other table
        /// </summary>
        public RoomType Type { get; set; }

        /// <summary>
        /// Room hotlel id - foregin key
        /// </summary>
        public Guid HotlelId { get; set; }

        /// <summary>
        /// Room hotel - other table
        /// </summary>
        public Hotel Hotlel { get; set; }

        /// <summary>
        /// List of reservation - other table
        /// </summary>
        public List<Reservation> Reservations { get; set; }

        /// <summary>
        /// List of room images - other table
        /// </summary>
        public List<RoomImages> RoomImages { get; set; } = new List<RoomImages>();

        /// <summary>
        /// Main romm image from room images
        /// </summary>
        public RoomImages MainImage => RoomImages?.Find(x => x.IsMain);

    }
}
