using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Service;

namespace HotelReservationWPF.ViewModel.Interfaces
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> type);
        void ShowAlert(string message, string title = "");
        DialogResult GetYesNoDialog(string message, string title = "");
    }
}