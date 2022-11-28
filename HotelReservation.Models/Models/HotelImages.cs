using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("HotelImages")]
    public class HotelImages
    {
        /// <summary>
        /// Hotel image id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Hotel image file extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Hotel image upload file
        /// </summary>
        public DateTime Upload_time { get; set; }

        /// <summary>
        /// Hotel image saved path 
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Hotel image falg is main
        /// </summary>
        public bool IsMain { get; set; } = false;

        /// <summary>
        /// Hotel image hotel id - foregin key
        /// </summary>
        public Guid HotelId { get; set; }

        /// <summary>
        /// Hotel images hotel - other table
        /// </summary>
        public Hotel Hotel { get; set; }

    }
}
