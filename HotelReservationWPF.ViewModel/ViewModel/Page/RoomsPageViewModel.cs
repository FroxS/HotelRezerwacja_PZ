using HotelReservation.Core.Service;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Page
{
    public class RoomsPageViewModel : BasePageWithItemsViewModel
    {
        #region Private properties

        private readonly IRoomService _roomService;
        private Room _selectedRoom;
        private bool _isEditing = false;
        private RoomViewModel _roomViewModel;
        private ObservableCollection<Room> _rooms;
        private DateTime? _startDate;
        private DateTime? _endDate;

        #endregion

        #region Public properties

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
                IsEditing = false;
                if (RoomViewModel != null)
                {
                    RoomViewModel.SaveAsync().ContinueWith((o) => {
                        _selectedRoom = value;
                        OnPropertyChanged(nameof(SelectedRoom));
                        if (_selectedRoom != null)
                            RoomViewModel = new RoomViewModel(_selectedRoom, _service) { Title = $"Edycja - {_selectedRoom.Name}" };
                    });
                }
                else
                {
                    _selectedRoom = value;
                    OnPropertyChanged(nameof(SelectedRoom));
                    if (_selectedRoom != null)
                        RoomViewModel = new RoomViewModel(_selectedRoom, _service) { Title = $"Edycja - {_selectedRoom.Name}" };
                } 
            }
        }

        public RoomViewModel RoomViewModel
        {
            get => _roomViewModel;
            set
            {
                _roomViewModel = value;
                OnPropertyChanged(nameof(RoomViewModel));
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

        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                Collection.Filter += Filter;

            }
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                Collection.Filter += Filter;
            }
        }

        #endregion

        #region Commands

        public ICommand AddNewCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand BookCommand { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RoomsPageViewModel(IServiceProvider service): base(service) 
        {
            _roomService = service.GetService<IRoomService>();
            AddNewCommand = new AsyncRelayCommand((o) => AddNew());
            DeleteCommand = new AsyncRelayCommand((o) => Delete((o as Room) == null ? _selectedRoom : (Room)o));
            EditCommand = new RelayCommand((o) => IsEditing = true);
            BookCommand = new RelayCommand<Room>(Book);
            LoadData();
        }

        #endregion

        #region Private methods

        protected override bool Filter(object emp)
        {
            if(emp is Room room)
            {
                bool flag = true;
                if (!string.IsNullOrWhiteSpace(Search))
                {
                    flag = flag && room.Name.ToLower().Contains(Search.ToLower());
                }
                if(StartDate.HasValue && EndDate.HasValue)
                {
                    IReservationService reservationService = _service.GetService<IReservationService>();

                    var avaiable = reservationService.IsRooomAvailable(room.Id, StartDate.Value, EndDate.Value);

                    flag = flag && avaiable;
                }

                flag = flag && room.HotlelId == _hotelApp.WorkingHotel;
                return flag;
            }

            return base.Filter(emp);
        }

        private void Book(Room room)
        {
            if (room == null)
                return;

            var bookVM = new BookPageViewModel(_service);
            bookVM.FilterRoom = (o) => o.Id == room.Id;
            bookVM.Reservation.StartDate = StartDate.HasValue ? StartDate.Value : DateTime.Now;
            bookVM.Reservation.EndDate = EndDate.HasValue ? EndDate.Value : DateTime.Now.AddDays(1);

            SetPage(HotelReservation.Models.Enum.EApplicationPage.BookPage, bookVM);
        }

        private async Task AddNew()
        {
            var created = new Room();

            if (RoomViewModel != null)
                await RoomViewModel.SaveAsync();

            Rooms.Add(created);
            _selectedRoom = created;
            RoomViewModel = new RoomViewModel(created, _service) { Title = "Dodaj nowy pokój", IsEditing = true };
            OnPropertyChanged(nameof(SelectedRoom));
        }

        private async Task Delete(Room room)
        {
            var guid = room?.Id ?? Guid.Empty;
            if(guid != Guid.Empty)
            {
                await _roomService.DeleteAsync(guid);
                Rooms.Remove(_selectedRoom);
            }
        }

        private async Task LoadData()
        {
            var rooms = await _roomService.GetAllAsync();
            Rooms = new ObservableCollection<Room>(rooms.Where(x => x.HotlelId == _hotelApp.WorkingHotel));
            Collection = CollectionViewSource.GetDefaultView(Rooms);
        }

        #endregion

    }
}