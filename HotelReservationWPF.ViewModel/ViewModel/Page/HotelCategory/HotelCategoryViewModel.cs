using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HotelReservation.Core.Service;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationWPF.ViewModel.Page
{
    public class HotelCategoryViewModel : BaseItemViewModel<HotelCategory>
    {
        #region Private properties

        private bool _isEditing = false;

        #endregion

        #region Public properties

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

        public ICommand EditCommad { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public HotelCategoryViewModel(HotelCategory hotelCategory, IServiceProvider service):base(hotelCategory, service)
        { 
            EditCommad = new RelayCommand((o) => { ChangeToEdit(); });
        }

        #endregion

        #region Public methods

        private void ChangeToEdit()
        {
            if (CanEditRows())
                IsEditing = true;
            else
            {
                IsEditing = false;
                MessageBox.Show("Brak uprawnień");
            }
        }

        public override async Task SaveAsync()
        {
            var hotelcategoryService = _service.GetService<IHotelCategoryService>();
            if (Item.Id == Guid.Empty)
            {
                var created = await hotelcategoryService.CreateAsync(Item);
                Item.Id = created.Id;
            }
            else
            { 
                await hotelcategoryService.UpdateAsync(Item);
            }
        }

        #endregion
    }
}