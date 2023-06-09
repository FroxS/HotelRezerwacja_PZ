using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for RoomsPageView.xaml
    /// </summary>
    public partial class RoomsPageView : BasePage<RoomsPageViewModel>, IRoomsPage
    {
        public RoomsPageView(RoomsPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
