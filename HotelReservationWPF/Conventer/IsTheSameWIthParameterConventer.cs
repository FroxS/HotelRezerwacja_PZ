using HotelReservation.Models.Enum;
using System;
using System.Globalization;

namespace HotelReservationWPF.Conventer
{
    /// <summary>
    /// Base value conventer that allows direct XMAL usage
    /// </summary>
    /// <typeparam name="T">The type of this value conventer </typeparam>
    public class IsPageTheSameWithParameterConventer : BaseValueConventer<IsPageTheSameWithParameterConventer>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (EApplicationPage)parameter == (EApplicationPage)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}