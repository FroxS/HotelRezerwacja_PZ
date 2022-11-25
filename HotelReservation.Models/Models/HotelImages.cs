using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("HotelImages")]
    public class HotelImages
    {
        [Key]
        public Guid Id { get; set; }

        public string Extension { get; set; }

        public DateTime Upload_time { get; set; }

        public string Path { get; set; }

        public bool IsMain { get; set; } = false;

        public Guid HotelId { get; set; }

        public Hotel Hotel { get; set; }

    }
}
