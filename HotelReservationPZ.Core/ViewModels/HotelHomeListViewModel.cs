using System;

namespace HotelReservation.Core.ViewModels
{
    public class HotelHomeListViewModel
    {
        /// <summary>
        /// Id of hotel
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of hotel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City of hotel
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Category of hotel
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Room prices range
        /// </summary>
        public string Prices { get; set; }

        /// <summary>
        /// Main image path of hotel
        /// </summary>
        public string Image { get; set; }
    }
}
