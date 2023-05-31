using HotelReservation.Models.Enum;


namespace HotelReservation.Core.WPFInterfaces
{
    public interface INavigation
    {
        EApplicationPage Page { get; }
        void SetPage(EApplicationPage page);
    }
}