using HotelReservation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class HotelImageForm
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public Guid CategoryId { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}
