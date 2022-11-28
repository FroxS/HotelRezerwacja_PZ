using System;

namespace HotelReservation.Core.ViewModels
{
    public class GuestReservationViewModel
    {
        /// <summary>
        /// Id of reservation
        /// </summary>
        public Guid ReservationId { get; set; }

        /// <summary>
        /// Date of check in reservation
        /// </summary>
        public DateTime Check_in { get; set; }

        /// <summary>
        /// Date of check out reservation
        /// </summary>
        public DateTime Check_out { get; set; }

        /// <summary>
        /// Date of check in reservation
        /// </summary>
        public string Check_in_date => Check_in.ToString("dd.MM.yyyy");

        /// <summary>
        /// Date of check out reservation
        /// </summary>
        public string Check_out_date => Check_out.ToString("dd.MM.yyyy");

        /// <summary>
        /// Time of check in reservation
        /// </summary>
        public string Check_in_time=> Check_in.ToString("HH:mm");

        /// <summary>
        /// Time of check out reservation
        /// </summary>
        public string Check_out_time=> Check_out.ToString("HH:mm");

        /// <summary>
        /// First name of Guest
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of guest
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Room name
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Room description
        /// </summary>
        public string RoomDescription { get; set; }

        /// <summary>
        /// Count of room
        /// </summary>
        public int CountOfRoom { get; set; }

        /// <summary>
        /// Count of adults
        /// </summary>
        public int CountOfAdults { get; set; }

        /// <summary>
        /// Count of Children
        /// </summary>
        public int CountOfChildren { get; set; }

        /// <summary>
        /// Name of Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Guest street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Guest Street number
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Guest ZipCode
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Guest City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Additional info of reservation
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Guest email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Guest phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Name of hotel
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// Id of hotel
        /// </summary>
        public string HoteId { get; set; }

        /// <summary>
        /// Total price of reservation
        /// </summary>
        public double TotalPrice { get; set; }
    }
}
