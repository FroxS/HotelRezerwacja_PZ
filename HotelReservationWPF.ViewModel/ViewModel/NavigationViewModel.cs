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
using System.Threading.Tasks;

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
            SetPageCommand = new AsyncRelayCommand<EApplicationPage>(async (o) => { await SetPage(o); });
            //SetPage(EApplicationPage.RoomsPage);
        }

        #endregion

        #region Public Methods

        public async Task SetPage(EApplicationPage page, BasePageViewModel pageViewModel = null)
        {
            try
            {
                if (page == Page)
                    return;

                if (!CanChagePage(page))
                    return;
                _service.GetService<IHotelReservationApp>().IsTaskRunning = true;

                OnPropertyChanging(nameof(Page));
                OnPropertyChanging(nameof(PageControl));
                Page = page;
                var newPageControl = page.ToBasePage(AppHost.Services);
                if (pageViewModel != null)
                    newPageControl.ViewModelObject = pageViewModel;
                PageViewModel = newPageControl.ViewModelObject as BasePageViewModel;
                await PageViewModel.LoadAsync();
                PageControl = newPageControl;
                _service.GetService<IHotelReservationApp>().IsTaskRunning = false;
                OnPropertyChanged(nameof(Page));
                OnPropertyChanged(nameof(PageControl));
            }
            catch(Exception ex)
            {
                _service.GetService<IHotelReservationApp>().IsTaskRunning = false;
            }
            finally
            {
                _service.GetService<IHotelReservationApp>().IsTaskRunning = false;
            }
            
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