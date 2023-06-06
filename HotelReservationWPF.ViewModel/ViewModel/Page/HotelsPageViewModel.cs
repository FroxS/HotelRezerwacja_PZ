using HotelReservation.Core.Service;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Service;
using Microsoft.Extensions.DependencyInjection;using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Page
{
    public class HotelsPageViewModel : BasePageWithItemsViewModel
    {
        #region Private properties

        private readonly IRoomService _roomService;
        private Hotel _selectedHotel;
        private bool _isEditing = false;
        private HotelListViewModel _hotelViewModel;
        private ObservableCollection<Hotel> _hotels;

        #endregion

        #region Public properties

        public ObservableCollection<Hotel> Hotels
        {
            get => _hotels;
            set
            {
                _hotels = value;
                OnPropertyChanged(nameof(Hotels));
            }
        }

        public Hotel SelectedHotel
        {
            get => _selectedHotel;
            set
            {
                IsEditing = false;
                if (HotelViewModel != null)
                {
                    //Hottel.SaveAsync().ContinueWith((o) => {
                    //    _selectedHotel = value;
                    //    OnPropertyChanged(nameof(SelectedRoom));
                    //    if (_selectedHotel != null)
                    //        RoomViewModel = new HotelListViewModel(_selectedHotel, _service) { Title = $"Edycja - {_selectedRoom.Name}" };
                    //});
                }
                else
                {
                    //_selectedRoom = value;
                    //OnPropertyChanged(nameof(SelectedRoom));
                    //if (_selectedRoom != null)
                    //    RoomViewModel = new HotelListViewModel(_selectedRoom, _service) { Title = $"Edycja - {_selectedRoom.Name}" };
                }
            }
        }

        public HotelListViewModel HotelViewModel
        {
            get => _hotelViewModel;
            set
            {
                _hotelViewModel = value;
                OnPropertyChanged(nameof(HotelViewModel));
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

        public ICommand AddNewCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public HotelsPageViewModel(IServiceProvider service) : base(service)
        {
            _roomService = service.GetService<IRoomService>();
            AddNewCommand = new AsyncRelayCommand((o) => AddNew());
            DeleteCommand = new AsyncRelayCommand((o) => Delete((o as Hotel) == null ? _selectedHotel : (Hotel)o));
            EditCommand = new RelayCommand((o) => IsEditing = true);
            LoadData();
        }

        #endregion

        #region Private methods

        protected override bool Filter(object emp)
        {
            if (emp is Room room)
            {
                bool flag = true;
                if (!string.IsNullOrWhiteSpace(Search))
                {
                    flag = flag && room.Name.ToLower().Contains(Search.ToLower());
                }

                flag = flag && room.HotlelId == _hotelApp.WorkingHotel;
                return flag;
            }

            return base.Filter(emp);
        }

        private async Task AddNew()
        {
            var created = new Hotel();

            //if (HotelViewModel != null)
            //    await HotelViewModel.SaveAsync();

            Hotels.Add(created);
            _selectedHotel = created;
            HotelViewModel = new HotelListViewModel() {};
            OnPropertyChanged(nameof(HotelViewModel));
        }

        private async Task Delete(Hotel hotel)
        {
            var guid = hotel?.Id ?? Guid.Empty;
            if (guid != Guid.Empty)
            {
                await _roomService.DeleteAsync(guid);
                Hotels.Remove(_selectedHotel);
            }
        }

        private async Task LoadData()
        {
            var rooms = await _roomService.GetAllAsync();
            Hotels = new ObservableCollection<Hotel>(_hotels);
            Collection = CollectionViewSource.GetDefaultView(Hotels);
        }

        #endregion
    }
}