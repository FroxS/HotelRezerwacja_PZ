using HotelReservation.Core.Service;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Page
{
    public class ReservationsPageViewModel : BasePageViewModel
    {
        #region Private properties

        private readonly IReservationService _reservationService;
        private Reservation _selectedReservation;
        private ObservableCollection<Reservation> _reservations;
        private string _search;


        #endregion

        #region Public properties

        public ObservableCollection<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        public Reservation SelectedReservation 
        { 
            get => _selectedReservation;
            set {
                _selectedReservation = value;
                OnPropertyChanged(nameof(SelectedReservation));
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        #endregion

        #region Commands

        public ICommand ShowDetailsCommad { get; private set; }
        public ICommand AddBookCommad { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReservationsPageViewModel(IServiceProvider service) : base(service)
        {
            _reservationService = service.GetService<IReservationService>();
            ShowDetailsCommad = new AsyncRelayCommand<Reservation>(ShowDetails);
            AddBookCommad = new RelayCommand((o) => AddBook());
            LoadReservations();
        }

        #endregion

        #region Private methods

        private async Task ShowDetails(Reservation reservation)
        {
            if (reservation == null)
                return;
            INavigation nav = _service.GetService<INavigation>();
            nav.SetPage(HotelReservation.Models.Enum.EApplicationPage.ReservationDetailsPage);
            await (nav.PageViewModel as ReservationDetailsPageViewModel).LoadReservation(reservation.Id);
        }

        private void AddBook()
        {
            INavigation nav = _service.GetService<INavigation>();
            nav.SetPage(HotelReservation.Models.Enum.EApplicationPage.BookPage);
        }

        private async Task LoadReservations()
        {
            var resertations = await _reservationService.GetReservations();
            Reservations = new ObservableCollection<Reservation>(resertations);
        }

        #endregion
    }
}