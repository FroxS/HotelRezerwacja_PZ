using System;

namespace HotelReservation.Core.ViewModels
{
    public class HotelListViewModel
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
        /// Description of hotel
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Citi of hotel
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Hottel category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Hotel price
        /// </summary>
        public string Prices { get; set; }

        /// <summary>
        /// Main image of hotel
        /// </summary>
        public string Image { get; set; }
    }
}
