using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    [Table("Address")]
    public class Address
    {
        /// <summary>
        /// Addres id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Addres country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Addres street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Addres street number
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Addres zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Addres city
        /// </summary>
        public string City { get; set; }


        public Address Clone()
        {
            return new Address
            {
                Id = this.Id,
                Country = this.Country,
                Street = this.Street,
                StreetNumber = this.StreetNumber,
                ZipCode = this.ZipCode,
                City = this.City
            };
        }
    }
}
