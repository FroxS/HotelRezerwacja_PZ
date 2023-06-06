using HotelReservationWPF.ViewModel.Interfaces;
using System.Windows;

namespace HotelReservationWPF.Dialog
{
    /// <summary>
    /// Interaction logic for BaseDialogWindow.xaml
    /// </summary>
    public partial class BaseDialogWindow : Window , IDialogWindow
    {
        public FrameworkElement Control
        {
            get => ControlPresenter.Content as FrameworkElement;
            set
            {
                ControlPresenter.Content = value;
                DataContext = value.DataContext;
            }
        }

        public BaseDialogWindow()
        {
            InitializeComponent();
        }
    }
}
