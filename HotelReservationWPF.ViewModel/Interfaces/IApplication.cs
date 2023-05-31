

namespace HotelReservationWPF.ViewModel.Interfaces
{
    public interface IApplication
    {
        bool? DialogResult { get; set; }
        void Close();
        void Show();
        bool? ShowDialog();
    }
}