using HotelReservation.Core.Repository;
using HotelReservation.Core.Service;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationWPF.ViewModel.Page
{
    public class SettingsPageViewModel : BasePageViewModel
    {
        #region Private properties

        protected IHotelService _hotelService => _service.GetService<IHotelService>();
        protected ObservableCollection<Hotel> _hotel;
        protected Hotel _selectedHotel;
        protected bool _canChageHotel;

        #endregion

        #region Public properties

        public bool CanChageHotel => _hotelApp.CanChangeHotel();

        public ObservableCollection<Hotel> Hotels
        {
            get => _hotel;
            set
            {
                _hotel = value;
                OnPropertyChanged(nameof(Hotels));
            }
        }

        public Hotel SelectedHotel
        {
            get => _selectedHotel;
            set
            {
                _selectedHotel = value;
                if (_selectedHotel != null)
                    _hotelApp.ChangeHotel(_selectedHotel.Id);

                OnPropertyChanged(nameof(SelectedHotel));

            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsPageViewModel(IServiceProvider service): base(service) 
        {
            LoadAsync();
        }

        #endregion

        #region Constructors

        private async Task LoadAsync()
        {
            var hotels = await _hotelService.GetAllAsync();
            Hotels = new ObservableCollection<Hotel>(hotels);

            SelectedHotel = Hotels.FirstOrDefault(x => x.Id == _hotelApp.WorkingHotel);
        }

        #endregion
    }
}