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
    public class HotelService : IHotelService
    {
        private readonly IHotelsRepository _hotelsRepository;
        public HotelService(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository;
        }

        public Hotel Create(Hotel item)
        {
            _hotelsRepository.Insert(item);
            _hotelsRepository.Save();
            return item;
        }
        public void Delete(Guid id)
        {
            _hotelsRepository.Delete(id);
            _hotelsRepository.Save();
        }
        public Hotel Get(Guid id)
        {
            var item = _hotelsRepository.GetById(id);
            return item;
        }

        public HotelListViewModel GetVM(Guid id)
        {
            var item = _hotelsRepository.GetById(id);
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

        public IEnumerable<Hotel> GetAll()
        {
            List<Hotel> items = _hotelsRepository.Get();
            return items;
        }

        public IEnumerable<Hotel> GetTop(int max = 3)
        {
            return _hotelsRepository.Get().Take(max);
        }

        public IEnumerable<HotelHomeListViewModel> GetForHomeList(int max = 5)
        {
            return _hotelsRepository.Get().Select(x => new HotelHomeListViewModel() {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                Prices = getPries(x.Rooms),
                City = x.City,
                Image = x.MainImage.Path
            }).Take(max);
        }

        public IEnumerable<HotelListViewModel> GetForList()
        {
            return _hotelsRepository.Get().Select(x => new HotelListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                Prices = getPries(x.Rooms),
                City = x.City,
                Image = x.MainImage.Path
            });
        }

        public void Update(Guid id, Hotel item)
        {
            _hotelsRepository.Update(item);
        }

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

    }
}
