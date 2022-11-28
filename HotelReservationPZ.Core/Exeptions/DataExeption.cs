using System;

namespace HotelReservation.Core.Exeptions
{
    public class DataExeption : Exception
    {
        public DataExeption(string message) : base(message)
        {
        }

    }
}
