using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;

namespace HotelReservationWPF.ViewModel.Interfaces
{
    public interface INavigation
    {
        EApplicationPage Page { get; }

        BasePageViewModel PageViewModel { get; set; }
        void SetPage(EApplicationPage page, BasePageViewModel pageViewModel = null);
    }
}