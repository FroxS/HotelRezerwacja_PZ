using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace HotelReservationWPF.ViewModel
{
    public class HotelReservationApp : BaseViewModel, IHotelReservationApp
    {
        #region Private Fields

        private readonly IServiceProvider _service;

        #endregion

        #region Public properties

        public IMainWindow MainWindow { get; }

        #endregion

        #region Constructor

        public HotelReservationApp(IServiceProvider service)
        {
            _service = service;
            MainWindow = _service.GetService<IMainWindow>();
        }


        #endregion

        #region Public methods

        public void Run()
        {
            MainWindow.ShowDialog();
        }

        public void Close()
        {
            //var window = _service.GetService<System.Windows.Appli>();
            //window.ShowDialog();
        }

        #endregion
    }
}
