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
    public class RoomService : IRoomService
    {
        #region Private Properties

        /// <summary>
        /// Repository of rooms
        /// </summary>
        private readonly IRoomsRepository _roomsRepository;

        /// <summary>
        /// Repository of reservation
        /// </summary>
        private readonly IReservationService _reservationService;

        #endregion

        #region Constructors

        /// <summary>
        /// Deafult constructor
        /// </summary>
        /// <param name="roomsRepository">Repository of room</param>
        /// <param name="reservationService">Repository of reservation</param>
        public RoomService(IRoomsRepository roomsRepository, IReservationService reservationService)
        {
            _roomsRepository = roomsRepository;
            _reservationService = reservationService;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to create a Room
        /// </summary>
        /// <param name="form">Created room</param>
        /// <param name="wwwpath">Path to savea a image</param>
        /// <returns></returns>
        public async Task<Room> CreateAsync(RoomImageFormViewModel form, string wwwpath)
        {

            if (form == null) throw new DataExeption("Pusty formularz");

            if (form.Images == null) throw new DataExeption("Brak zdjęć");

            if (form.Images.Count < 5) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.Images), "Minimalna liczba zdjęć hotelu to 5");

            if (form.TypeId == Guid.Empty) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.TypeId), "Nie wybrano typu pokoju");

            if (form.MaxQuantityOfPeople < 0) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.MaxQuantityOfPeople), "Maksymalna liczba osób jest mniejsza do 1");

            if (form.HotlelId == Guid.Empty) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.HotlelId), "Nie przypisano pokoju");

            if (string.IsNullOrEmpty(form.Description)) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.Description), "Brak opisu");

            if (string.IsNullOrEmpty(form.Name)) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.Name), "Brak nazwy pokoju");

            if (form.Price <= 0) throw new ErrorModelExeption(nameof(RoomImageFormViewModel.Price), "Cena jest niepoprawna");

            Room room = new Room()
            {
                Id = Guid.NewGuid(),
                Name = form.Name,
                Description = form.Description,
                MaxQuantityOfPeople = form.MaxQuantityOfPeople,
                Discount = 1,
                Price = form.Price,
                TypeId = form.TypeId,
                HotlelId = form.HotlelId,
                RoomImages = new List<RoomImages>()
            };

            if (form.Images != null)
            {
                bool flagIsMain = true;
                foreach (IFormFile Imageform in form?.Images)
                {
                    var path = await UploadFile(Imageform, Path.Combine("Images", "Room"), wwwpath);
                    if (!string.IsNullOrEmpty(path))
                    {
                        room.RoomImages.Add(new RoomImages()
                        {
                            Id = Guid.Parse(Path.GetFileNameWithoutExtension(path)),
                            Extension = Path.GetExtension(path),
                            IsMain = flagIsMain,
                            Path = path,
                            Upload_time = DateTime.Now,
                            Room = room,
                            RoomId = room.Id
                        });
                        flagIsMain = false;
                    }
                }
            }

            await _roomsRepository.InsertAsync(room);
            await _roomsRepository.SaveAsync();
            return room;
        }

        /// <summary>
        /// Method to delete room
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _roomsRepository.DeleteAsync(id);
            await _roomsRepository.SaveAsync();
        }

        /// <summary>
        /// Method to get room by id
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        public async Task<RoomDetailsViewModel> GetAsync(Guid id)
        {
            return new RoomDetailsViewModel(await _roomsRepository.GetByIdAsync(id));
        }

        /// <summary>
        /// Method to get all rooms
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            List<Room> items = await _roomsRepository.GetAllAsync();
            return items;
        }

        /// <summary>
        /// Method to get filtred list of room
        /// </summary>
        /// <param name="hotel">Id of hotel</param>
        /// <param name="name">Name of room</param>
        /// <returns></returns>
        public async Task<IEnumerable<RoomListViewModel>> GetListAsync(Guid hotel, string? name)
        {
            if(hotel == Guid.Empty)
            {
                return (await _roomsRepository.GetAllAsync())
                    .Where(x => x.Name.ToLower().Contains(name?.ToLower() ?? ""))
                    .Select(x => new RoomListViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.MainImage.Path,
                    Type = x.Type.Name,
                    Price = $"{x.Price} zł",
                });
            }
            else
            {
                return (await _roomsRepository.GetAllAsync())
                    .Where(x => x.HotlelId == hotel && x.Name.ToLower().Contains(name?.ToLower() ?? ""))
                    .Select(x => new RoomListViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Image = x.MainImage.Path,
                        Type = x.Type.Name,
                        Price = $"{x.Price} zł",
                    }
                );
            }
            
        }

        /// <summary>
        /// Method to get filtred list of room
        /// </summary>
        /// <param name="hotel">Id of hotel</param>
        /// <param name="name">Name of roo</param>
        /// <param name="check_in">Check in of rervation</param>
        /// <param name="check_out">Check out of rervation</param>
        /// <returns></returns>
        public async Task<IEnumerable<RoomListViewModel>> GetListAsync(Guid hotel, string name, DateTime check_in, DateTime check_out)
        {
            List<RoomListViewModel> tmp = new List<RoomListViewModel>();
            foreach(RoomListViewModel vm in (await GetListAsync(hotel, name)))
            {
                if (await _reservationService.IsRooomAvailableAsync(vm.Id, check_in, check_out))
                    tmp.Add(vm);
            }
            return tmp;

        }

        /// <summary>
        /// Method to update room
        /// </summary>
        /// <param name="item">Room to update</param>
        /// <returns></returns>
        public async Task UpdateAsync(Room item)
        {
            _roomsRepository.Update(item);
            await _roomsRepository.SaveAsync();
        }

        #endregion

        #region Private methods

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
            {
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
