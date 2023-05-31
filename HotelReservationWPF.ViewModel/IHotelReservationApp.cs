using HotelReservationWPF.ViewModel.Interfaces;
using System.Windows;

namespace HotelReservationWPF.ViewModel
{
    public interface IHotelReservationApp
    {
        IMainWindow MainWindow { get; }
        void Run();
        void Close();
    }
}