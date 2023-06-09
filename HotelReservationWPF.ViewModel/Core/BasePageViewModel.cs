using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HotelReservationWPF.ViewModel.Core
{
    public class BasePageViewModel : BaseViewModel
    {
        #region Protected properties

        protected readonly IServiceProvider _service;
        protected Guid WorkingHotel => _service.GetService<IHotelReservationApp>().WorkingHotel;
        protected INavigation _nav => _service.GetService<INavigation>();
        protected IHotelReservationApp _hotelApp => _service.GetService<IHotelReservationApp>();

        #endregion

        #region Protected properties

        public Action<BasePageViewModel> OnDataLoaded { protected get; set; }

        #endregion 

        #region Constructor

        public BasePageViewModel(IServiceProvider service)
        {
            _service = service;
        }

        #endregion

        #region Protected method

        protected async Task SetPage(EApplicationPage page)
        {
            await _nav.SetPage(page);
        }

        protected async Task SetPage(EApplicationPage page,BasePageViewModel pageViewMOdel = null)
        {
            await _nav.SetPage(page, pageViewMOdel);
        }

        protected bool CanEditRows() => _hotelApp.UserType == (EUserType.Employee | EUserType.Boss);

        #endregion

        #region Public methods

        public virtual Task LoadAsync() { return Task.Delay(0); }

        #endregion

    }
}