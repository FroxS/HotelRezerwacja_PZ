using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Service;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.ViewModel.Dialog
{
    public class YesNoDialogViewModel : DialogViewModelBase<DialogResult>
    {
        #region Private properties

        #endregion

        #region Public properties

        public override ICommand OKCommand { get; protected set; }

        public ICommand NoCommand { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public YesNoDialogViewModel(string title, string message) : base(title, message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
        }


        #endregion

        #region Command methods

        private void Yes(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.Yes);
        }

        private void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.No);
        }

        #endregion
    }
}