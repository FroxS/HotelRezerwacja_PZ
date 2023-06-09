using HotelReservation.Core.Service;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Page
{
    public class ReservationDetailsPageViewModel : BasePageViewModel
    {
        #region Private properties

        private readonly IReservationService _reservationService;
        private bool _isEditing;
        private Reservation _reservation;

        #endregion

        #region Public properties

        public Reservation Reservation
        {
            get => _reservation;
            set
            {
                _reservation = value;
                OnPropertyChanged(nameof(Reservation));
            }
        }

        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }

        #endregion

        #region Commands

        public ICommand EditCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand CanelCommand { get; private set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReservationDetailsPageViewModel(IServiceProvider service) : base(service)
        {
            _reservationService = service.GetService<IReservationService>();
            EditCommand = new RelayCommand((o) => { IsEditing = true; });
            SaveCommand = new AsyncRelayCommand((o) => Save(), (o) => MessageBox.Show("Wystąpił bład"));
            CanelCommand = new AsyncRelayCommand((o) => Canel());
        }

        #endregion

        #region Commands methods

        private async Task Save()
        {
            if (IsEditing)
            {
                await Task.Run(() => { });
            }
        }

        private async Task Canel()
        {
            if(MessageBox.Show("Czy na pewno usunac rezerwecję ?","Usuwanie",MessageBoxButton.YesNoCancel,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if(await _reservationService.CanelReservation(Reservation.Id))
                {
                    MessageBox.Show("Udał osię ununąć rezerwacje");
                    await SetPage(HotelReservation.Models.Enum.EApplicationPage.ReservationPage);
                    return;
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć rezerwacji.");
                }
            }
        }

        #endregion

        #region Public methods

        public async Task LoadReservation(Guid reservationID)
        {
            Reservation = await _reservationService.GetReservation(reservationID);
        }

        #endregion
    }
}