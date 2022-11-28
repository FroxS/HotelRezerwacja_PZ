using System;
using System.Collections.Generic;

namespace HotelReservation.Core.Exeptions
{
    public class ErrorModelExeption : Exception
    {
        #region Private properties

        /// <summary>
        /// Dictionary for messaged of exeption
        /// </summary>
        private readonly Dictionary<string, string> _dict;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructro
        /// </summary>
        /// <param name="propName">Name of property</param>
        /// <param name="value">Value of error assign to property</param>
        public ErrorModelExeption(string propName, string value):base()
        {
            _dict = new Dictionary<string, string>();
            _dict.Add(propName, value);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dict">Disctionay of properties nad vaule od errors</param>
        public ErrorModelExeption(Dictionary<string, string> dict) : base()
        {
            _dict = dict;
        }

        #endregion

        #region Public method

        /// <summary>
        /// Method fo get all data of errors
        /// </summary>
        /// <returns>Data of errors</returns>
        public IDictionary<string, string> GetData() => _dict;

        #endregion
    }
}
