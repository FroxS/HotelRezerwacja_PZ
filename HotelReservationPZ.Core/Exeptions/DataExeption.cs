using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Exeptions
{
    public class DataExeption : Exception
    {
        public DataExeption(string message) : base(message)
        {
        }

    }
}
