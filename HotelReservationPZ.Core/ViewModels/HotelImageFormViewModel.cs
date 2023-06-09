using HotelReservation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class HotelImageFormViewModel
    {
        /// <summary>
        /// Name of hotel
        /// </summary>
        [Required(ErrorMessage ="Wpisz nazwę hotelu")]
        public string Name { get; set; }

        /// <summary>
        /// Description of hotel
        /// </summary>
        [Required(ErrorMessage = "Wpisz opis hotelu")]
        public string Description { get; set; }

        /// <summary>
        /// Citi of hotel
        /// </summary>
        [Required(ErrorMessage = "Wpisz miasto hotelu")]
        public string City { get; set; }

        /// <summary>
        /// Id hotel active
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Min hours of check in 
        /// </summary>
        [Required]
        public int HoursCheckOutFrom { get; set; }

        /// <summary>
        /// Max hours of check in 
        /// </summary>
        [Required]
        public int HoursCheckOutTo { get; set; }

        /// <summary>
        /// Min hours of check out 
        /// </summary>
        [Required]
        public int HoursCheckInFrom { get; set; }

        /// <summary>
        /// Max hours of check out 
        /// </summary>
        [Required]
        public int HoursCheckInTo { get; set; }

        /// <summary>
        /// Id of category hotel
        /// </summary>
        [Required(ErrorMessage = "Wybierz kategorie")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// List of hotel images 
        /// </summary>
        [Required(ErrorMessage = "Wybierz zdjęcia, minimum 3")]
        public List<IFormFile> Images { get; set; }

        public HotelImageFormViewModel() { }

        public HotelImageFormViewModel(Hotel hotel) : this()
        {
            Name = hotel.Name;
            Description = hotel.Description;
            City = hotel.City;
            IsActive = hotel.IsActive;
            HoursCheckOutFrom = hotel.HoursCheckOutFrom;
            HoursCheckOutTo = hotel.HoursCheckOutTo;
            HoursCheckInFrom = hotel.HoursCheckInFrom;
            HoursCheckInTo = hotel.HoursCheckInTo;
            CategoryId = hotel.Category == null ? hotel.CategoryId : hotel.Category.Id;
        }
    }
}
