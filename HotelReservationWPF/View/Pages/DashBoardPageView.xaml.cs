using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for DashBoardPageView.xaml
    /// </summary>
    public partial class DashBoardPageView : BasePage<DashBoardPageViewModel>, IDashBoardPage
    {
        public DashBoardPageView(DashBoardPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
