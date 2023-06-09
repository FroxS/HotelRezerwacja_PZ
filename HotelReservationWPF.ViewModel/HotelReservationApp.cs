using HotelReservation.Core.Service;
using HotelReservation.Models;
using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace HotelReservationWPF.ViewModel
{
    public class HotelReservationApp : BaseViewModel, IHotelReservationApp
    {
        #region Private Fields

        private readonly IServiceProvider _service;
        private Guid _workingHotel;

        #endregion

        #region Public properties

        public IMainWindow MainWindow { get; }

        public Guid WorkingHotel 
        { 
            get => _workingHotel;
            private set {
                _workingHotel = value;
                OnPropertyChanged(nameof(WorkingHotel));
                Properties.Settings.Default.WorkingHotel = _workingHotel;
                Properties.Settings.Default.Save();
            }
        }

        public EUserType UserType { get; private set; }

        public IDialogService DialogService => _service.GetService<IDialogService>();

        public INavigation Navigation => _service.GetService<INavigation>();

        #endregion

        #region Constructor

        public HotelReservationApp(IServiceProvider service)
        {
            _service = service;
            MainWindow = _service.GetService<IMainWindow>();
            WorkingHotel = Properties.Settings.Default.WorkingHotel;
            UserType = EUserType.Admin;
        }


        #endregion

        #region Public methods

        public bool CanEditRows() => UserType == EUserType.Admin || UserType == EUserType.Boss;

        public bool CanChangeHotel() => UserType == EUserType.Admin || UserType == EUserType.Boss;

        public Hotel GetWorkingHotel() => _service.GetService<IHotelService>().Get(this.WorkingHotel);

        public void Run()
        {
            Navigation.SetPage(EApplicationPage.DashBoard);
            MainWindow.ShowDialog();
        }

        public void Close()
        {
        }

        public void ChangeHotel(Guid hotelID)
        {
            if (CanChangeHotel())
            {
                WorkingHotel = hotelID;
            }
        }

        public string GetApplicationPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        #endregion
    }
}
