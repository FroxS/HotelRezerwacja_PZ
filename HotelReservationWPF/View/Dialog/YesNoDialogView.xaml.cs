using HotelReservationWPF.ViewModel.ViewModel.Dialog;
using System.Windows.Controls;

namespace HotelReservationWPF.View.Dialog
{
    /// <summary>
    /// Interaction logic for YesNoDialogView.xaml
    /// </summary>
    public partial class YesNoDialogView : UserControl
    {
        public YesNoDialogView(YesNoDialogViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
