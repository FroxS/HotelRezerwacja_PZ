using HotelReservationWPF.Controls;
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Page;

namespace HotelReservationWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for BookPageView.xaml
    /// </summary>
    public partial class BookPageView : BasePage<BookPageViewModel>, IBookPage
    {
        public BookPageView(BookPageViewModel? vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
