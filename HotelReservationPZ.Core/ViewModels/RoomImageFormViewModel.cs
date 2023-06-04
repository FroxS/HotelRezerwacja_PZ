using HotelReservation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class RoomImageFormViewModel
    {
        /// <summary>
        /// Name of room
        /// </summary>
        [Required(ErrorMessage = "Wpisz nazwę pokoju")]
        public string Name { get; set; }

        /// <summary>
        /// Description of room
        /// </summary>
        [Required(ErrorMessage = "Wpisz opis pokoju")]
        public string Description { get; set; }

        /// <summary>
        /// Room price
        /// </summary>
        [Required(ErrorMessage = "Podaj cene")]
        public double Price { get; set; }

        /// <summary>
        /// Room max quantity of people
        /// </summary>
        [Required(ErrorMessage = "Podaj maksymalną liczbę osób")]
        public int MaxQuantityOfPeople { get; set; }

        /// <summary>
        /// Id of hotel
        /// </summary>
        [Required(ErrorMessage = "Wybierz hotel")]
        public Guid HotlelId { get; set; }

        /// <summary>
        /// If of room type
        /// </summary>
        [Required(ErrorMessage = "Wybierz typ pokoju")]
        public Guid TypeId { get; set; }

        /// <summary>
        /// List of room images
        /// </summary>
        [Required(ErrorMessage = "Wybierz zdjęcia, minimum 5")]
        public List<IFormFile> Images { get; set; }

        public RoomImageFormViewModel() { }

        public RoomImageFormViewModel(Room room):this()
        {
            Name = room.Name;
            Description = room.Description;
            Price = room.Price;
            MaxQuantityOfPeople = room.MaxQuantityOfPeople;
            TypeId = room.Type.Id == Guid.Empty ? room.TypeId : room.Type.Id;
            HotlelId = room.Hotlel.Id == Guid.Empty ? room.HotlelId : room.Hotlel.Id;
        }

    }
}
