using System;

namespace HotelReservation.Core.ViewModels
{
    public class GuestReservationViewModel
    {
        public Guid ReservationId { get; set; }

        public DateTime Check_in { get; set; }

        public DateTime Check_out { get; set; }

        public string Check_in_date => Check_in.ToString("dd.MM.yyyy");
        public string Check_out_date => Check_out.ToString("dd.MM.yyyy");
        public string Check_in_time=> Check_in.ToString("HH:mm");
        public string Check_out_time=> Check_out.ToString("HH:mm");

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RoomName { get; set; }

        public string RoomDescription { get; set; }

        public int CountOfRoom { get; set; }

        public int CountOfAdults { get; set; }

        public int CountOfChildren { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string AdditionalInfo { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string HotelName { get; set; }

        public string HoteId { get; set; }

        public double TotalPrice { get; set; }
    }
}
