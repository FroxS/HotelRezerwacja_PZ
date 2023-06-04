using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Interfaces;
using System;

namespace HotelReservationWPF.ViewModel
{
    public interface IHotelReservationApp
    {
        IMainWindow MainWindow { get; }
        public Guid WorkingHotel { get; }
        EUserType UserType { get; }
        void Run();
        void Close();
        string GetApplicationPath();
        bool CanEditRows();
        bool CanChangeHotel();
        void ChangeHotel(Guid hotelID);
    }
}