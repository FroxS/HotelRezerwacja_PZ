using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace HotelReservationWPF.ViewModel.Core
{
    public static class AplicationPageConventer
    {
        /// <summary>
        /// Takes a <see cref="ApplicationPage"/> and the viem model if any and creates the desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static IBasePage ToBasePage(this EApplicationPage page, IServiceProvider services)
        {
            switch (page)
            {
                case EApplicationPage.DashBoard:
                    return services.GetRequiredService<IDashBoardPage>();
                case EApplicationPage.ReservationPage:
                    return services.GetRequiredService<IReservationsPage>();
                case EApplicationPage.RoomsPage:
                    return services.GetRequiredService<IRoomsPage>();
                case EApplicationPage.HotelsPage:
                    return services.GetRequiredService<IHotelsPage>();
                case EApplicationPage.ReservationDetailsPage:
                    return services.GetRequiredService<IReservationDetailsPage>();
                case EApplicationPage.BookPage:
                    return services.GetRequiredService<IBookPage>();
                case EApplicationPage.Settings:
                    return services.GetRequiredService<ISettingsPage>();
                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}