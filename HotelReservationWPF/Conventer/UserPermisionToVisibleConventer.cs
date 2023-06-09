using HotelReservation.Core.Helpers;
using HotelReservation.Models.Attributes;
using HotelReservation.Models.Enum;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows;

namespace HotelReservationWPF.Conventer
{
    /// <summary>
    /// Base value conventer that allows direct XMAL usage
    /// </summary>
    /// <typeparam name="T">The type of this value conventer </typeparam>
    public class UserPermisionToVisibleConventer : BaseValueConventer<UserPermisionToVisibleConventer>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is EUserType userTpye && parameter is EApplicationPage page)
            {
                var permision = page.GetAttributeOfType<PermisionAttribute>();
                if(permision != null)
                {
                    if ((permision.Type & userTpye) != userTpye)
                    {
                        return Visibility.Collapsed;
                    }
                }
            }
            return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}