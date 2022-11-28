using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("RoomImages")]
    public class RoomImages
    {
        /// <summary>
        /// Room images id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Room images file extention
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Room images upload date
        /// </summary>
        public DateTime Upload_time { get; set; }

        /// <summary>
        /// Room images path of file
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Room images flag is active
        /// </summary>
        public bool IsMain { get; set; } = false;

        /// <summary>
        /// Room images room id - foregin key
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Room images room - other table
        /// </summary>
        public Room Room { get; set; }

    }
}
