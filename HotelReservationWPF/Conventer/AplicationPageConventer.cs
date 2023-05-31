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
                //case EApplicationPage.Products:
                //    return services.GetRequiredService<ProductsPage>();
                //case EApplicationPage.Suppliers:
                //    return services.GetRequiredService<SuppliersPage>();
                //case EApplicationPage.ProductGroups:
                //    return services.GetRequiredService<ProductGroupPage>();

                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}