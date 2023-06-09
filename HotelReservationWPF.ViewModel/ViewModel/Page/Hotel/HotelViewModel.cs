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
using HotelReservationWPF.ViewModel.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationWPF.ViewModel.Page
{
    public class HotelViewModel : BaseItemViewModel<Hotel>
    {
        #region Private properties

        private ObservableCollection<HotelCategory> _hotelCategories;
        private ObservableCollection<IFormFile> _images;
        private bool _isEditing = false;
        private ObservableCollection<int> _hours = new ObservableCollection<int>(Enumerable.Range(1,23));

        #endregion

        #region Public properties

        public ObservableCollection<HotelCategory> HotelCategories
        { 
            get => _hotelCategories;
            private set {
                _hotelCategories = value;
                OnPropertyChanged(nameof(HotelCategories));
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

        public ObservableCollection<int> Hours
        {
            get => _hours;
            private set
            {
                _hours = value;
                OnPropertyChanged(nameof(Hours));
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
        public HotelViewModel(Hotel hotel, IServiceProvider service):base(hotel, service)
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
            HotelCategories = new ObservableCollection<HotelCategory>(await _service.GetService<IHotelCategoryService>().GetAllAsync());
            string appPath = GetApplicationPath();
            Images = new ObservableCollection<IFormFile>(Item.Images.Select(
                x => new CustomFromFile(
                    File.ReadAllBytes(Path.Combine(appPath, x.Path)),
                   Path.Combine(appPath, x.Path)
                )));
        }

        public override async Task SaveAsync()
        {
            var hotelService = _service.GetService<IHotelService>();

            if (Item.Id == Guid.Empty)
            {
                HotelImageFormViewModel form = new HotelImageFormViewModel(Item);
                form.Images = Images.ToList();
                var created = await hotelService.CreateAsync(form, GetApplicationPath());
                Item.Id = created.Id;
            }
            else
            {
                var itemToUpdate = Item.Clone();
                itemToUpdate.CategoryId = Guid.Empty;
                await hotelService.UpdateAsync(Item);
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