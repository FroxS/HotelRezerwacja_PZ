using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HotelReservation.Core.Helpers;
using HotelReservation.Core.Service;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using HotelReservationWPF.ViewModel.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationWPF.ViewModel.Page
{
    public class RoomViewModel : BaseItemViewModel<Room>
    {
        #region Private properties

        private ObservableCollection<RoomType> _roomTypes;
        private ObservableCollection<IFormFile> _images;
        private bool _isEditing = false;

        #endregion

        #region Public properties

        public ObservableCollection<RoomType> RoomTypes 
        { 
            get => _roomTypes;
            private set { 
                _roomTypes = value;
                OnPropertyChanged(nameof(RoomTypes));
            }
        }

        public ObservableCollection<IFormFile> Images
        {
            get => _images;
            private set
            {
                _images = value;
                OnPropertyChanged(nameof(Images));
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

        public ICommand UploadImagesCommad { get; private set; }
        public ICommand EditCommad { get; private set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RoomViewModel(Room room, IServiceProvider service):base(room,service)
        { 
            UploadImagesCommad = new RelayCommand((o) => UploadImages());
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

        public override async Task LoadAsync()
        {
            RoomTypes = new ObservableCollection<RoomType>(await _service.GetService<IRoomTypeService>().GetAllAsync());
            string appPath = GetApplicationPath();
            Images = new ObservableCollection<IFormFile>(Room.RoomImages.Select(
                x => new CustomFromFile(
                    File.ReadAllBytes(Path.Combine(appPath, x.Path)),
                   Path.Combine(appPath, x.Path)
                )));
        }

        public override async Task SaveAsync()
        {
            var roomService = _service.GetService<IRoomService>();
            Room.HotlelId = _service.GetService<IHotelReservationApp>().WorkingHotel;
            if (Room.Id == Guid.Empty)
            {
                RoomImageFormViewModel form = new RoomImageFormViewModel(Room);
                form.Images = Images.ToList();
                var created = await roomService.CreateAsync(form, GetApplicationPath());
                Room.Id = created.Id;
            }
            else
            {
                await roomService.UpdateAsync(Room);
            }
        }


        private void UploadImages()
        {
            try
            {
                string[] files = GetImagesDialog();
                if (files != null)
                {
                    foreach (string file in files)
                    {
                        var bytes = File.ReadAllBytes(file);
                        Images.Add(new CustomFromFile(bytes, file));
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania zdjęć!");
            }
            
        }

        #endregion
    }
}