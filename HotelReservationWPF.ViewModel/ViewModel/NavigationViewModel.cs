using HotelReservation.Models.Attributes;
using HotelReservation.Models.Enum;
using HotelReservation.Models.WPFModel;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HotelReservation.Core.Helpers;
using System;

namespace HotelReservationWPF.ViewModel
{
    public class NavigationViewModel : BaseViewModel, INavigation
    {

        #region Private properties

        private readonly IServiceProvider _service;

        #endregion

        #region Public properties

        public IHost? AppHost { get; set; }

        public EApplicationPage Page { get; protected set; }

        public BasePageViewModel PageViewModel { get; set; }

        public EUserType UserType => _service.GetService<IHotelReservationApp>().UserType;

        public ObservableCollection<NavItem> NavItems { get; protected set; }

        public IBasePage PageControl { get; private set; }

        #endregion

        #region Public Commands

        public ICommand SetPageCommand { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationViewModel(IServiceProvider service)
        {
            _service = service;
            SetPageCommand = new RelayCommand<EApplicationPage>((o) => { SetPage(o); });
            //SetPage(EApplicationPage.RoomsPage);
        }

        #endregion

        #region Public Methods

        public void SetPage(EApplicationPage page, BasePageViewModel pageViewModel = null)
        {
            if (page == Page)
                return;

            if (!CanChagePage(page))
                return;

            OnPropertyChanging(nameof(Page));
            OnPropertyChanging(nameof(PageControl));
            Page = page;
            var newPageControl = page.ToBasePage(AppHost.Services);
            if (pageViewModel != null)
                newPageControl.ViewModelObject = pageViewModel;
            PageViewModel = newPageControl.ViewModelObject as BasePageViewModel;
            PageControl = newPageControl;
           
            OnPropertyChanged(nameof(Page));
            OnPropertyChanged(nameof(PageControl));
        }


        private bool CanChagePage(EApplicationPage page)
        {
            EUserType userTpye = UserType;
            var permision = page.GetAttributeOfType<PermisionAttribute>();
            if (permision != null)
            {
                if ((permision.Type & userTpye) != userTpye)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}