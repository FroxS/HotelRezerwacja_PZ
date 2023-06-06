using HotelReservation.Models.Enum;
using HotelReservationWPF.View.Dialog;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Service;
using HotelReservationWPF.ViewModel.ViewModel.Dialog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Windows;

namespace HotelReservationWPF.Dialog
{
    public class DialogService : IDialogService
    {
        #region Private properties

        private readonly IServiceProvider _service;

        #endregion

        #region Public methods

        public T OpenDialog<T>(DialogViewModelBase<T> wm)
        {
            IDialogWindow window = new BaseDialogWindow();
            var control = GetControlDialog(wm);
            if (control == null)
                throw new ArgumentException("Dialog now found");
            window.Control = control;
            window.ShowDialog();
            return wm.DialogResult;

        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DialogService(IServiceProvider service)
        {
            _service = service;
        }

        #endregion

        #region Private methods

        public FrameworkElement? GetControlDialog<T>(DialogViewModelBase<T> wm)
        {
            if (wm is AlertDialogViewModel alertVM)
                return new AlertDialogView(alertVM);
            if (wm is YesNoDialogViewModel yesNoVM)
                return new YesNoDialogView(yesNoVM);

            Debugger.Break();
            return null;
        }

        #endregion

        #region Public method

        public void ShowAlert(string message, string title = "")
        {
            OpenDialog(new AlertDialogViewModel(message, title));
        }

        public DialogResult GetYesNoDialog(string message, string title = "")
        {
            return OpenDialog(new YesNoDialogViewModel(message, title));
        }

        #endregion
    }
}