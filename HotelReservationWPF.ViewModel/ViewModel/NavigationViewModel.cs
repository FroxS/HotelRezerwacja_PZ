using HotelReservation.Core.WPFInterfaces;
using HotelReservation.Models.Enum;
using HotelReservation.Models.WPFModel;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Page;
using Microsoft.Extensions.Hosting;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel
{
    public class NavigationViewModel : BaseViewModel, INavigation
    {
        #region Private properties

        #endregion

        #region Public properties

        public IHost? AppHost { get; set; }

        public EApplicationPage Page { get; protected set; }

        public ObservableCollection<NavItem> NavItems { get; protected set; }

        #endregion

        #region Public Commands

        public ICommand SetPageCommand { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationViewModel()
        {
            SetPageCommand = new RelayCommand<EApplicationPage>((o) => { SetPage(o); });
            SetPage(EApplicationPage.DashBoard);
        }

        #endregion

        #region Public Methods

        public void SetPage(EApplicationPage page)
        {
            OnPropertyChanging(nameof(Page));
            Page = page;
            OnPropertyChanged(nameof(Page));
        }

        #endregion
    }
}