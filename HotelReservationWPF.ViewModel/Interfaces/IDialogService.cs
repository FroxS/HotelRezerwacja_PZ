using System.Windows;

namespace HotelReservationWPF.ViewModel.Interfaces
{
    public interface IDialogWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        FrameworkElement Control { get; set; }
        bool? ShowDialog();
    }
}