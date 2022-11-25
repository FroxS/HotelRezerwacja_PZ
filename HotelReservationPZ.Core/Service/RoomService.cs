using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomsRepository _roomsRepository;
        private readonly IReservationService _reservationService;
        public RoomService(IRoomsRepository roomsRepository, IReservationService reservationService)
        {
            _roomsRepository = roomsRepository;
            _reservationService = reservationService;
        }

        public Room Create(Room item)
        {
            _roomsRepository.Insert(item);
            _roomsRepository.Save();
            return item;
        }
        public void Delete(Guid id)
        {
            _roomsRepository.Delete(id);
            _roomsRepository.Save();
        }
        public Room Get(Guid id)
        {
            var item = _roomsRepository.GetById(id);
            return item;
        }
        public IEnumerable<Room> GetAll()
        {
            List<Room> items = _roomsRepository.Get();
            return items;
        }
        public IEnumerable<RoomListViewModel> GetList(Guid hotel, string? name)
        {
            if(hotel == Guid.Empty)
            {
                return _roomsRepository.Get()
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
                return _roomsRepository.Get()
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

        public IEnumerable<RoomListViewModel> GetList(Guid hotel, string name, DateTime check_in, DateTime check_out)
        {
            return GetList(hotel, name).Where(x => _reservationService.IsRooomAvailable(x.Id, check_in, check_out));

        }
        public void Update(Guid id, Room item)
        {
            _roomsRepository.Update(item);
        }

    }
}
