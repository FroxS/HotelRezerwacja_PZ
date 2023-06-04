using HotelReservation.Models.Enum;
using HotelReservationWPF.Controls;
using HotelReservationWPF.View.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace HotelReservationWPF.Conventer
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
                    return services.GetRequiredService<DashBoardPageView>();
                case EApplicationPage.ReservationPage:
                    return services.GetRequiredService<ReservationsPageView>();
                case EApplicationPage.RoomsPage:
                    return services.GetRequiredService<RoomsPageView>();
                case EApplicationPage.HotelsPage:
                    return services.GetRequiredService<HotelsPageView>();
                case EApplicationPage.ReservationDetailsPage:
                    return services.GetRequiredService<ReservationDetailsPageView>();
                case EApplicationPage.BookPage:
                    return services.GetRequiredService<BookPageView>();
                case EApplicationPage.Settings:
                    return services.GetRequiredService<SettingsPageView>();
                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}