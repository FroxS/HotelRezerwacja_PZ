using HotelReservation.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HotelReservationWPF.Conventer
{
    /// <summary>
    /// Base value conventer that allows direct XMAL usage
    /// </summary>
    /// <typeparam name="T">The type of this value conventer </typeparam>
    public class IFromFileToImageSourceConventer : BaseValueConventer<IFromFileToImageSourceConventer>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage imageSource = new BitmapImage();
            if (value is IFormFile file)
            {
                //return ToImage(file.FileFytes);
                using (Stream ms = file.OpenReadStream())
                {
                    return ToImage(ms);
                }
            }
            return imageSource;
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