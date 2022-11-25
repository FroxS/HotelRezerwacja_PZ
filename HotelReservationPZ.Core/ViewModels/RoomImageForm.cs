using HotelReservation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class RoomImageForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int MaxQuantityOfPeople { get; set; }

        [Required]
        public Guid HotlelId { get; set; }

        [Required]
        public Guid TypeId { get; set; }

        public List<IFormFile> Images { get; set; }

    }
}
