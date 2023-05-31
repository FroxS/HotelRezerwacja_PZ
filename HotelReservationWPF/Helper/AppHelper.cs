using HotelReservation.Core.WPFInterfaces;
using HotelReservationWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationWPF.Helper
{
    public class AppHelper
    {
        #region Public properties
        /// <summary>
        /// Singleton instance fo the lacator
        /// </summary>
        public static AppHelper Instance { get; private set; } = new AppHelper();

        /// <summary>
        /// The aplication view model
        /// </summary>
        public static INavigation Navigation => App.AppHost.Services.GetRequiredService<INavigation>();

        /// <summary>
        /// The aplication view model
        /// </summary>
        public static IHotelReservationApp Application => App.AppHost.Services.GetRequiredService<IHotelReservationApp>();

        #endregion
    }
}