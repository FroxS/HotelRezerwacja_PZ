using HotelReservationWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Media.Imaging;

namespace HotelReservationWPF.Conventer
{
    /// <summary>
    /// Base value conventer that allows direct XMAL usage
    /// </summary>
    /// <typeparam name="T">The type of this value conventer </typeparam>
    public class AddFullPathImageConventer : BaseValueConventer<AddFullPathImageConventer>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value is string file)
            {
                string mianPath = App.AppHost.Services.GetService<IHotelReservationApp>().GetApplicationPath();
                return Path.Combine(mianPath, file); ;
            }
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                return ToImage(ms);
            }
        }

        public BitmapImage ToImage(Stream ms)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad; // here
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
    }
}