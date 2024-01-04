using HotelReservation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace HotelReservation.Core.ViewModels
{
    public class RoomDetailsViewModel : Room
    {
        #region Private properties

        /// <summary>
        /// Room
        /// </summary>
        private readonly Room room;

        #endregion

        #region Public propertiess

        /// <summary>
        /// Calculated price with discount
        /// </summary>
        public double DiscountPrice => room.Price * room.Discount;

        /// <summary>
        /// List of path room image
        /// </summary>
        public List<string> Images => room.RoomImages.Select(room => room.Path).ToList();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="room">Room</param>
        public RoomDetailsViewModel(Room room)
        {
            this.room = room;
            // Pobierz informacje o właściwościach obiektów
            PropertyInfo[] wlasciwosciZrodlo = room.GetType().GetProperties();
            PropertyInfo[] wlasciwosciCel = GetType().GetProperties();

            // Przejdź przez wszystkie właściwości obiektu źródłowego
            foreach (var wlasciwoscZrodlo in wlasciwosciZrodlo)
            {
                // Znajdź odpowiadającą właściwość w obiekcie docelowym
                var wlasciwoscCel = Array.Find(wlasciwosciCel, p => p.Name == wlasciwoscZrodlo.Name);

                // Jeżeli istnieje właściwość o takiej samej nazwie, skopiuj wartość
                if (wlasciwoscCel != null && wlasciwoscCel.PropertyType == wlasciwoscZrodlo.PropertyType)
                {
                    if (wlasciwoscCel.GetSetMethod() != null)
                    {
                        var wartosc = wlasciwoscZrodlo.GetValue(room);
                        wlasciwoscCel.SetValue(this, wartosc);

                    }
                    
                }
            }
        }

        #endregion
    }
}
