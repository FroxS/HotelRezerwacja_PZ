using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        protected void SetPage(EApplicationPage page)
        {
            _nav.SetPage(page);
        }

        protected void SetPage(EApplicationPage page,Action<BasePageViewModel> OnPageChaged)
        {
            SetPage(page);
            _nav.PageViewModel.OnDataLoaded = OnPageChaged;
        }

        protected bool CanEditRows() => _hotelApp.UserType == (EUserType.Employee | EUserType.Boss);

        #endregion

    }
}