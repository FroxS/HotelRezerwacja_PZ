using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        /// <summary>
        /// Hotel Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Hotel name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hotel description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Hotel city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// IsActive hotel
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Hotel hours check out from
        /// </summary>
        public int HoursCheckOutFrom { get; set; }

        /// <summary>
        /// Hotel hours check out to
        /// </summary>
        public int HoursCheckOutTo{ get; set; }

        /// <summary>
        /// Hotel hours check in from
        /// </summary>
        public int HoursCheckInFrom { get; set; }

        /// <summary>
        /// Hotel hours check oin to
        /// </summary>
        public int HoursCheckInTo { get; set; }

        /// <summary>
        /// Hotel categoryId - foregin key
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Hotel category - other table
        /// </summary>
        public HotelCategory Category { get; set; }

        /// <summary>
        /// Hotel rooms - other table
        /// </summary>
        public List<Room> Rooms { get; set; }

        /// <summary>
        /// Hotel images - other table
        /// </summary>
        public List<HotelImages> Images { get; set; } = new List<HotelImages>();

        /// <summary>
        /// Hotel main image from images
        /// </summary>
        public HotelImages MainImage => Images?.Find(x => x.IsMain);

        public Hotel Clone()
        {
            return new Hotel
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                City = this.City,
                IsActive = this.IsActive,
                HoursCheckOutFrom = this.HoursCheckOutFrom,
                HoursCheckOutTo = this.HoursCheckOutTo,
                HoursCheckInFrom = this.HoursCheckInFrom,
                HoursCheckInTo = this.HoursCheckInTo,
                CategoryId = this.CategoryId,
                Category = this.Category,
                Rooms = this.Rooms,
                Images = new List<HotelImages>(this.Images),
            };
        }


    }
}
