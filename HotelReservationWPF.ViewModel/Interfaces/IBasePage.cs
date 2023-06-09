
namespace HotelReservationWPF.ViewModel.Interfaces
{
    public interface IBasePage
    {
        object ViewModelObject { get; set; }
    }

    public interface IDashBoardPage : IBasePage { }
    public interface IReservationsPage : IBasePage { }
    public interface IRoomsPage : IBasePage { }
    public interface IHotelsPage : IBasePage { }
    public interface IReservationDetailsPage : IBasePage { }
    public interface IBookPage : IBasePage { }
    public interface ISettingsPage : IBasePage { }
}