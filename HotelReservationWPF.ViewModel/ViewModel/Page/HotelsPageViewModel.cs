using HotelReservation.Core.Service;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Page
{
    public class HotelsPageViewModel : BasePageWithItemsViewModel
    {
        #region Private properties

        private readonly IHotelService _hotelService;
        private Hotel _selectedHotel;
        private bool _isEditing = false;
        private HotelViewModel _hotelViewModel;
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
                    HotelViewModel.SaveAsync().ContinueWith((o) =>
                    {
                        _selectedHotel = value;
                        OnPropertyChanged(nameof(SelectedHotel));
                        if (_selectedHotel != null)
                            HotelViewModel = new HotelViewModel(_selectedHotel, _service) { Title = $"Edycja - {_selectedHotel.Name}" };
                    });
                }
                else
                {
                    _selectedHotel = value;
                    OnPropertyChanged(nameof(SelectedHotel));
                    if (_selectedHotel != null)
                        HotelViewModel = new HotelViewModel(_selectedHotel, _service) { Title = $"Edycja - {_selectedHotel.Name}" };
                }
            }
        }

        public HotelViewModel HotelViewModel
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
            _hotelService = service.GetService<IHotelService>();
            AddNewCommand = new AsyncRelayCommand((o) => AddNew());
            DeleteCommand = new AsyncRelayCommand((o) => Delete((o as Hotel) == null ? _selectedHotel : (Hotel)o));
            EditCommand = new RelayCommand((o) => IsEditing = true);
           
        }

        #endregion

        #region Private methods

        protected override bool Filter(object emp)
        {
            if (emp is Hotel hotel)
            {
                bool flag = true;
                if (!string.IsNullOrWhiteSpace(Search))
                {
                    flag = flag && hotel.Name.ToLower().Contains(Search.ToLower());
                }
                return flag;
            }

            return base.Filter(emp);
        }

        private async Task AddNew()
        {
            var created = new Hotel();

            if (HotelViewModel != null)
                await HotelViewModel.SaveAsync();

            Hotels.Add(created);
            _selectedHotel = created;
            HotelViewModel = new HotelViewModel(created, _service) { Title = "Dodaj nowy hotel", IsEditing = true };
            OnPropertyChanged(nameof(SelectedHotel));
        }

        private async Task Delete(Hotel hotel)
        {
            var guid = hotel?.Id ?? Guid.Empty;
            if (guid != Guid.Empty)
            {
                await _hotelService.DeleteAsync(guid);
                Hotels.Remove(_selectedHotel);
            }
        }

        public override async Task LoadAsync()
        {
            var hotels = await _hotelService.GetAllAsync();
            Hotels = new ObservableCollection<Hotel>(hotels);
            Collection = CollectionViewSource.GetDefaultView(Hotels);
        }

        #endregion
    }
}