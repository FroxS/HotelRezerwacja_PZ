using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPageView.xaml
    /// </summary>
    public partial class SettingsPageView : BasePage<SettingsPageViewModel>, ISettingsPage
    {
        public SettingsPageView(SettingsPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
