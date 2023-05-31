

namespace HotelReservationWPF.ViewModel.Interfaces
{
    public interface IMainWindow
    {
        bool? DialogResult { get; set; }
        void Close();
        void Show();
        bool? ShowDialog();
    }
}