using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class HotelCategory
    {
        /// <summary>
        /// Hotel category id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Hotel category name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Hotel category hotels list - other table
        /// </summary>
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();

        public HotelCategory Clone()
        {
            return new HotelCategory
            {
                Id = this.Id,
                Name = this.Name,
                Hotels = new List<Hotel>(this.Hotels)
            };
        }
    }
}
