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
        [Key]
        public Guid Id { get; set; }

        public string Extension { get; set; }

        public DateTime Upload_time { get; set; }

        public string Path { get; set; }

        //public IFormFile ImageFile { get; set; }
        public bool IsMain { get; set; } = false;
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

    }
}
