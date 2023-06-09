using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for ReservationDetailsPageView.xaml
    /// </summary>
    public partial class ReservationDetailsPageView : BasePage<ReservationDetailsPageViewModel>, IReservationDetailsPage
    {
        public ReservationDetailsPageView(ReservationDetailsPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
