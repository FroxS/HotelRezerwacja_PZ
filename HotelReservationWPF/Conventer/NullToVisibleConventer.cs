using System;
using System.Globalization;
using System.Windows;

namespace HotelReservationWPF.Conventer
{
    /// <summary>
    /// Base value conventer that allows direct XMAL usage
    /// </summary>
    /// <typeparam name="T">The type of this value conventer </typeparam>
    public class NullToVisibleConventer : BaseValueConventer<NullToVisibleConventer>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}