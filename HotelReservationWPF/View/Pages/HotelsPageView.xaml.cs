using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for HotelsPageView.xaml
    /// </summary>
    public partial class HotelsPageView : BasePage<HotelsPageViewModel>
    {
        public HotelsPageView(HotelsPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
