using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        #region Private properties

        private readonly IServiceProvider _service;
        private INavigation _nav => _service.GetService<INavigation>();
        #endregion

        #region Public properties

        public ICommand SetPageCommand { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel(IServiceProvider service)
        {
            _service = service; 
            SetPageCommand = new RelayCommand<EApplicationPage>((o) => _nav.SetPage(o));
        }

        #endregion
    }
}