using HotelReservation.Models.Enum;
using System;

namespace HotelReservation.Models.WPFModel
{
    public class NavItem
    {
        #region Public properties

        public string Name { get; set; }

        public EApplicationPage Page { get; set; }

        #endregion

        #region Constructors

        public NavItem(string name,EApplicationPage page)
        {
            Name = name;
            Page = page;
        }

        #endregion
    }
}