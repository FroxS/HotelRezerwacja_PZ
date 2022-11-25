using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Exeptions
{
    public class ErrorModelExeption : Exception
    {

        private readonly Dictionary<string, string> _dict;

        public ErrorModelExeption(string PropName, string value):base()
        {
            _dict = new Dictionary<string, string>();
            _dict.Add(PropName, value);
        }

        public ErrorModelExeption(Dictionary<string, string> dict) : base()
        {
            _dict = dict;
        }

        public IDictionary<string, string> GetData() => _dict;
    }
}
