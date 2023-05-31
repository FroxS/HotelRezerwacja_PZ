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

        #endregion

        #region Constructor

        public BasePageViewModel(IServiceProvider service)
        {
            _service = service;
        }

        #endregion
    }
}