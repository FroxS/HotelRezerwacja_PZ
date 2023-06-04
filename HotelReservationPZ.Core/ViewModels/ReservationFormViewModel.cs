using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.ViewModels
{
    public class ReservationFormViewModel
    {
        /// <summary>
        /// Id of room
        /// </summary>
        [Required]
        public Guid RoomId { get; set; }

        /// <summary>
        /// Date of check in
        /// </summary>
        [Required(ErrorMessage = "Data zamedlowania jest pusta")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Date of check out
        /// </summary>
        [Required(ErrorMessage = "Data wymeldowania jest pusta")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        /// <summary>
        /// Guest first name
        /// </summary>
        [Required(ErrorMessage = "Wpisz swoje imie")]
        public string FirstName { get; set; }

        /// <summary>
        /// Guest last name
        /// </summary>
        [Required(ErrorMessage = "Wpisz swoje nazwisko")]
        public string LastName { get; set; }

        /// <summary>
        /// Room price
        /// </summary>
        public double RoomPrice { get; set; }

        /// <summary>
        /// Is person private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Guset street number 
        /// </summary>
        [Required(ErrorMessage = "Podaj numer domu")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Guset street
        /// </summary>
        [Required(ErrorMessage = "Wpisz ulice")]
        public string Street { get; set; }

        /// <summary>
        /// Deatilf of reservation
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Guest country
        /// </summary>
        [Required(ErrorMessage = "Wpisz kraj")]
        public string Country { get; set; }

        /// <summary>
        /// Count of room
        /// </summary>
        [Required(ErrorMessage = "Podaj ilosć pokoi")]
        public int CountOfRoom { get; set; } = 1;

        /// <summary>
        /// Count of children
        /// </summary>
        [Required(ErrorMessage = "Podaj ilosć dzieci")]
        public int CountOfChildren { get; set; } = 0;

        /// <summary>
        /// Count of aduts
        /// </summary>
        [Required(ErrorMessage = "Podaj ilosć dorosłych")]
        public int CountOfAdults { get; set; } = 1;

        /// <summary>
        /// Guset zip code
        /// </summary>
        [Required(ErrorMessage = "Brak kodu pocztowego")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Guest citi
        /// </summary>
        [Required(ErrorMessage = "Brak miasta")]
        public string City { get; set; }

        /// <summary>
        /// Guset email
        /// </summary>
        [Required(ErrorMessage = "Brak adresu email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres emial")]
        public string Email { get; set; }

        /// <summary>
        /// Guest phone
        /// </summary>
        [Phone(ErrorMessage ="Niepoprany numer telefonu")]
        [Required(ErrorMessage = "Brak numeru telefonu")]
        public string Phone { get; set; }

        public Guid AddresId { get; set; }
        public Guid GuestId { get; set; }
    }
}
