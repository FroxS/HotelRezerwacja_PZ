using HotelReservation.Core.Exeptions;
using HotelReservation.Core.Service;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using HotelReservation.Models.Enum;
using HotelReservationWPF.ViewModel.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Page
{
    public class BookPageViewModel : BasePageViewModel
    {
        #region Private properties

        private readonly IReservationService _reservationService;
        private ReservationFormViewModel _reservation;
        private ObservableCollection<Room> _rooms;
        private ObservableCollection<int> _hoursCheckIn;
        private int _selectedhoursCheckIn; 
        private ObservableCollection<int> _hoursCheckOut;
        private int _selectedhoursCheckOut; 
        private Room _selectedRoom;

        #endregion

        #region Public properties

        public ReservationFormViewModel Reservation
        {
            get => _reservation;
            set
            {
                _reservation = value;
                OnPropertyChanged(nameof(Reservation));
            }
        }

        public ObservableCollection<Room> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }

        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                Reservation.RoomId = _selectedRoom.Id;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        public ObservableCollection<int> HoursCheckIn
        {
            get => _hoursCheckIn;
            set
            {
                _hoursCheckIn = value;
                OnPropertyChanged(nameof(HoursCheckIn));
            }
        }

        public int SelectedHoursCheckIn
        {
            get => _selectedhoursCheckIn;
            set
            {
                _selectedhoursCheckIn = value;
                OnPropertyChanged(nameof(SelectedHoursCheckIn));
            }
        }

        public ObservableCollection<int> HoursCheckOut
        {
            get => _hoursCheckOut;
            set
            {
                _hoursCheckOut = value;
                OnPropertyChanged(nameof(HoursCheckOut));
            }
        }

        public int SelectedHoursCheckOut
        {
            get => _selectedhoursCheckOut;
            set
            {
                _selectedhoursCheckOut = value;
                OnPropertyChanged(nameof(SelectedHoursCheckOut));
            }
        }

        public Func<Room, bool> FilterRoom { private get; set; }

        #endregion

        #region Commands

        public ICommand BookCommand { get; private set; }

        public ICommand UpdateAviableRoomsCommand { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BookPageViewModel(IServiceProvider service) : base(service)
        {
            _reservationService = service.GetService<IReservationService>();
            BookCommand = new AsyncRelayCommand((o) => Book());
            UpdateAviableRoomsCommand = new AsyncRelayCommand((o) => SetAviableRooms());
            Reservation = new ReservationFormViewModel();
            LoadAsync();
        }


        #endregion

        #region Private methods

        private async Task LoadAsync()
        {
            try
            {
                IsTaskRunning = true;
                await Task.Delay(1000);
                var roomService = await _service.GetService<IRoomService>().GetAllAsync();
                Rooms = new ObservableCollection<Room>(roomService);
                var hotel = await _service.GetService<IHotelService>().GetAsync(WorkingHotel);
                HoursCheckIn = new ObservableCollection<int>(Enumerable.Range(hotel.HoursCheckInFrom, (hotel.HoursCheckInTo - hotel.HoursCheckInFrom) + 1));
                SelectedHoursCheckIn = HoursCheckIn.FirstOrDefault();
                HoursCheckOut = new ObservableCollection<int>(Enumerable.Range(hotel.HoursCheckOutFrom, (hotel.HoursCheckOutTo - hotel.HoursCheckOutFrom) + 1));
                SelectedHoursCheckOut = HoursCheckOut.FirstOrDefault();
                OnDataLoaded?.Invoke(this);
                OnPropertyChanged(nameof(Reservation));
                await SetAviableRooms();
                IsTaskRunning = false;
            }
            catch(System.Exception ex)
            {
                IsTaskRunning = false;
            }
            finally
            {
                IsTaskRunning = false;
            }
            

        }

        private async Task SetAviableRooms()
        {
            DateTime check_in = Reservation.StartDate;
            DateTime check_out = Reservation.EndDate;
            //if(check_out < check_in)
            //{
            //    MessageBox.Show("Zakres reserwacji jest nieprawidłowy");
            //    return;
            //}
            IRoomService roomService = _service.GetService<IRoomService>();
            List<Room> availableRooms = await roomService.GetAvailableRooms(WorkingHotel, check_in, check_out);
            //Guid selectedGuid = SelectedRoom.Id;

            Rooms = new ObservableCollection<Room>(availableRooms.Where(x => FilterRoom?.Invoke(x) ?? true));
            //if (Rooms.Count == 0)
            //{
            //    MessageBox.Show("Nie znaleziono pokojów w wybranym terminie");
            //}

        }

        #endregion

        #region Commands methods

        private async Task Book()
        {
            try
            {
                var start = Reservation.StartDate;
                var end = Reservation.EndDate;
                Reservation.StartDate = new DateTime(start.Year, start.Month, start.Day, SelectedHoursCheckIn, 0, 0);
                Reservation.EndDate = new DateTime(end.Year, end.Month, end.Day, SelectedHoursCheckOut, 0, 0);
                var reserwation = await _reservationService.BookAsync(Reservation);

                MessageBox.Show("Udało się zrobić rezerwację!");
                SetPage(EApplicationPage.ReservationPage, (pageVM) => {
                    if(pageVM is ReservationsPageViewModel reservationVM)
                    {
                        //reservationVM.SelectedReservation = reservationVM.Reservations.FirstOrDefault(x => x.Id == reserwation.Id);
                    }
                });


            }
            catch (ErrorModelExeption ex)
            {
                foreach(var message in ex.GetData())
                {
                    MessageBox.Show($"{message.Key} {message.Value}","Błąd");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błą podczas rezerwacji");
            }

        }


        #endregion
    }
}