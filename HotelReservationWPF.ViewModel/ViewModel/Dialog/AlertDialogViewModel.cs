using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Service;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.ViewModel.Dialog
{
    public class AlertDialogViewModel : DialogViewModelBase<DialogResult>
    {
        #region Public properties

        public override ICommand OKCommand { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AlertDialogViewModel(string message, string title = "") : base(title, message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(Yes);
        }

        #endregion

        #region Command methods

        private void Yes(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.Yes);
        }

        #endregion
    }
}