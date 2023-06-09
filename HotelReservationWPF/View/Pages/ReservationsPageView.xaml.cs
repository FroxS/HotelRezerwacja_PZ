using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for ReservationsPageView.xaml
    /// </summary>
    public partial class ReservationsPageView : BasePage<ReservationsPageViewModel>, IReservationsPage
    {
        public ReservationsPageView(ReservationsPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
