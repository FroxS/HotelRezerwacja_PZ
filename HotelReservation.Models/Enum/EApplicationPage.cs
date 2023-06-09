

using HotelReservation.Models.Attributes;

namespace HotelReservation.Models.Enum
{
    public enum EApplicationPage
    {
        None = 0,
        [Permision]
        DashBoard = 1,
        [Permision]
        ReservationPage = 2,
        [Permision]
        ReservationDetailsPage =4,
        [Permision]
        BookPage = 8,
        [Permision]
        RoomsPage = 16,
        [Permision(EUserType.Admin | EUserType.Boss)]
        HotelsPage = 32,
        [Permision(EUserType.Admin)]
        Settings = 64
    }
}