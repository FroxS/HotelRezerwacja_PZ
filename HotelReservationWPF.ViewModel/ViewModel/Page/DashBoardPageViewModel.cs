using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;
using System;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Page
{
    public class DashBoardPageViewModel : BasePageViewModel
    {
        #region Private properties

        #endregion

        #region Public properties

        public ICommand GoToPageCommand { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashBoardPageViewModel(IServiceProvider service): base(service) 
        {
            GoToPageCommand = new RelayCommand<EApplicationPage>(SetPage);
        }

        #endregion

        #region Commands methods

        #endregion

    }
}