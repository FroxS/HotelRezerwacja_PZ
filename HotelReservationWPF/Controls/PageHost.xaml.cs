using HotelReservation.Models.Enum;
using HotelReservationWPF.Conventer;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HotelReservationWPF.Controls
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public EApplicationPage CurrentPage
        {
            get => (EApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(
                nameof(CurrentPage),
                typeof(EApplicationPage),
                typeof(PageHost),
                new UIPropertyMetadata(
                    default(EApplicationPage),
                    null,
                    CurrentPagePropertyChanged)
                );

        #endregion

        #region Constructors

        public PageHost()
        {
            InitializeComponent();
        }

        #endregion

        #region Property Changed Events

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            if (value is EApplicationPage page)
            {
                PageHost pageHost = d as PageHost;
                if (pageHost == null)
                    return value;

                Frame? newPageFrame = pageHost.NewPage;
                var oldPageContent = newPageFrame.Content;

                // Remove current page from new page frame
                newPageFrame.Content = null;

                if (App.AppHost?.Services != null)
                {
                    INavigation nav = App.AppHost?.Services.GetService<INavigation>();
                    var newPage = page.ToBasePage(App.AppHost.Services);
                    nav.PageViewModel = newPage.ViewModelObject as BasePageViewModel;
                    newPageFrame.Content = newPage;
                }
                    
            }


            return value;
        }

        #endregion
    }
}
