using System;

namespace HotelReservation.Core.ViewModels
{
    public class HotelListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string City { get; set; }

        public string Category { get; set; }

        public string Prices { get; set; }

        public string Image { get; set; }
    }
}
