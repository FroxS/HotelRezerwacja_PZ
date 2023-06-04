using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for RoomsPageView.xaml
    /// </summary>
    public partial class RoomsPageView : BasePage<RoomsPageViewModel>
    {
        public RoomsPageView(RoomsPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
