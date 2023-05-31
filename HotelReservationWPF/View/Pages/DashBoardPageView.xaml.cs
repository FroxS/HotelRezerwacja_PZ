using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for DashBoardPageView.xaml
    /// </summary>
    public partial class DashBoardPageView : BasePage<DashBoardPageViewModel>
    {
        public DashBoardPageView(DashBoardPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
