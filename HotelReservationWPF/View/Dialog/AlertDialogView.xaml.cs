using HotelReservationWPF.ViewModel.ViewModel.Dialog;
using System.Windows.Controls;

namespace HotelReservationWPF.View.Dialog
{
    /// <summary>
    /// Interaction logic for AlertDialogView.xaml
    /// </summary>
    public partial class AlertDialogView : UserControl
    {
        public AlertDialogView(AlertDialogViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
