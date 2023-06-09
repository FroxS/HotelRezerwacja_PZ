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
    public class RoomTypeViewModel : BaseItemViewModel<RoomType>
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
        public RoomTypeViewModel(RoomType roomtype, IServiceProvider service):base(roomtype, service)
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
            var roomService = _service.GetService<IRoomTypeService>();
            if (Item.Id == Guid.Empty)
            {
                var created = await roomService.CreateAsync(Item);
                Item.Id = created.Id;
            }
            else
            { 
                await roomService.UpdateAsync(Item);
            }
        }

        #endregion
    }
}