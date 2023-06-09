using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;
using System.Threading.Tasks;

namespace HotelReservationWPF.ViewModel.Interfaces
{
    public interface INavigation
    {
        EApplicationPage Page { get; }
        EUserType UserType { get; }
        IBasePage PageControl { get; }
        BasePageViewModel PageViewModel { get; set; }
        Task SetPage(EApplicationPage page, BasePageViewModel pageViewModel = null);
    }
}