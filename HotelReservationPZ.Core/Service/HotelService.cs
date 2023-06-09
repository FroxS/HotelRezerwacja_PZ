using HotelReservation.Core.Exeptions;
using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class HotelService : IHotelService
    {
        #region Private Properties

        /// <summary>
        /// Repository of hotel
        /// </summary>
        private readonly IHotelsRepository _hotelsRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Deafult constructor
        /// </summary>
        /// <param name="hotelsRepository">Repository of hotel</param>
        public HotelService(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to create hotel
        /// </summary>
        /// <param name="hotel">Created hotel</param>
        /// <param name="imagePath">Path to save images</param>
        /// <returns></returns>
        public async Task<Hotel> CreateAsync(HotelImageFormViewModel hotel, string imagePath)
        {
            if (hotel == null) throw new DataExeption("Pusty formularz");

            if (hotel.Images == null) throw new DataExeption("Brak zdjęć");

            if (hotel.Images.Count < 1) throw new ErrorModelExeption(nameof(Hotel.Images), "Minimalna liczba zdjęć hotelu to 1");

            if (hotel.CategoryId == Guid.Empty) throw new ErrorModelExeption(nameof(Hotel.Category), "Nie wybrano kategori");

            if (string.IsNullOrEmpty(hotel.Description)) throw new ErrorModelExeption(nameof(Hotel.Description), "Brak opisu");

            if (string.IsNullOrEmpty(hotel.Name)) throw new ErrorModelExeption(nameof(Hotel.Name), "Brak nazwy hotelu");

            Hotel hotelEF = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = hotel.Name,
                Description = hotel.Description,
                City = hotel.City,
                HoursCheckInFrom = hotel.HoursCheckInFrom,
                HoursCheckInTo = hotel.HoursCheckInTo,
                HoursCheckOutFrom = hotel.HoursCheckOutFrom,
                HoursCheckOutTo = hotel.HoursCheckOutTo,
                IsActive = hotel.IsActive,
                CategoryId = hotel.CategoryId,
                Images = new List<HotelImages>()
            };

            if (hotel.Images != null)
            {
                bool flagIsMain = true;
                foreach (var form in hotel?.Images)
                {
                    var path = await UploadFile(form, Path.Combine("Images", "Hotel"), imagePath);
                    if (!string.IsNullOrEmpty(path))
                    {
                        hotelEF.Images.Add(new HotelImages()
                        {
                            Id = Guid.Parse(Path.GetFileNameWithoutExtension(path)),
                            Extension = Path.GetExtension(path),
                            IsMain = flagIsMain,
                            Path = path,
                            Upload_time = DateTime.Now,
                            Hotel = hotelEF,
                            HotelId = hotelEF.Id
                        });
                        flagIsMain = false;
                    }
                }
            }

            await _hotelsRepository.InsertAsync(hotelEF);
            await _hotelsRepository.SaveAsync();
            return hotelEF;
        }

        /// <summary>
        /// Method to delete hotel
        /// </summary>
        /// <param name="id">Id of this hotel</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _hotelsRepository.DeleteAsync(id);
            await _hotelsRepository.SaveAsync();
        }

        /// <summary>
        /// Method to get view model of hotel
        /// </summary>
        /// <param name="id">Id of hotel</param>
        /// <returns></returns>
        public async Task<Hotel> GetAsync(Guid id)
        {
            Hotel item = await _hotelsRepository.GetByIdAsync(id);
            return item;
        }

        /// <summary>
        /// Method to get view model of hotel
        /// </summary>
        /// <param name="id">Id of hotel</param>
        /// <returns></returns>
        public Hotel Get(Guid id)
        {
            Hotel item = _hotelsRepository.GetById(id);
            return item;
        }

        /// <summary>
        /// Method to gel all hotels to list
        /// </summary>
        /// <returns></returns>
        public async Task<HotelListViewModel> GetVMAsync(Guid id)
        {
            var item = await _hotelsRepository.GetByIdAsync(id);
            return new HotelListViewModel() {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Category = item.Category.Name,
                Prices = getPries(item.Rooms),
                City = item.City,
                Image = item.MainImage.Path
            };
        }

        /// <summary>
        /// Method to gel all hotels to list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HotelListViewModel>> GetAllVMAsync()
        {
            List<HotelListViewModel> items = (await GetAllAsync()).Select(item =>
                new HotelListViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Category = item.Category.Name,
                    Prices = getPries(item.Rooms),
                    City = item.City,
                    Image = item.MainImage.Path
                }
                ).ToList();
            return items;
        }

        /// <summary>
        /// Method to gel all hotels to list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Hotel>> GetAllAsync()
        {
            List<Hotel> items = (await _hotelsRepository.GetAllAsync());
            return items;
        }



        /// <summary>
        /// Methof to get only hotels
        /// </summary>
        /// <param name="max">Maximim items in list</param>
        /// <returns></returns>
        public async Task<IEnumerable<Hotel>> GetTopAsync(int max = 3)
        {
            return (await _hotelsRepository.GetAllAsync()).Take(max);
        }

        /// <summary>
        /// Method to get list of hotels for home viev 
        /// </summary>
        /// <param name="max">Maximim items in list</param>
        /// <returns></returns>
        public async Task<IEnumerable<HotelHomeListViewModel>> GetForHomeListAsync(int max = 5)
        {
            return (await _hotelsRepository.GetAllAsync()).Select(x => new HotelHomeListViewModel() {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                Prices = getPries(x.Rooms),
                City = x.City,
                Image = x.MainImage.Path
            }).Take(max);
        }

        /// <summary>
        /// Method to get list of hotels
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HotelListViewModel>> GetForListAsync()
        {
            return (await _hotelsRepository.GetAllAsync()).Select(x => new HotelListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                Prices = getPries(x.Rooms),
                City = x.City,
                Image = x.MainImage.Path
            });
        }

        /// <summary>
        /// Method to update hotel
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Hotel item)
        {
            _hotelsRepository.Update(item);
            await _hotelsRepository.SaveAsync();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to get room price range
        /// </summary>
        /// <param name="rooms">List of rooms</param>
        /// <returns></returns>
        private string getPries(IEnumerable<Room> rooms)
        {
            if (rooms == null)
                return "";
            if (rooms.Count() < 1)
                return "";
            double min = rooms.Min(x => x.Price);
            double max = rooms.Max(x => x.Price);
            if (min == max) return $"{min} zł";
            return $"{min} zł - {max} zł";
        }

        /// <summary>
        /// Method to save file on server
        /// </summary>
        /// <param name="form">Form of file image</param>
        /// <param name="path">Path to save</param>
        /// <param name="wwwPath">Dicretroy path of server</param>
        /// <returns></returns>
        private async Task<string> UploadFile(IFormFile form, string path, string wwwPath)
        {
            string file = null;

            if (form != null)
            {;
                file = Guid.NewGuid().ToString() + Path.GetExtension(form.FileName);
                file = Path.Combine(path, file);
                using (var fs = new FileStream(Path.Combine(wwwPath, file), FileMode.Create))
                {
                    await form.CopyToAsync(fs);
                }
            }

            return file;
        }

        #endregion
    }
}
