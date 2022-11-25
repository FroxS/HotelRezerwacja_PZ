using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class HotelCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
