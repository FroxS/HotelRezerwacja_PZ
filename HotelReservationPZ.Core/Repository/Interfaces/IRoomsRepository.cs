using HotelReservation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Repository
{
    public interface IRoomsRepository: IBaseRepository<Room>
    {
        Task<List<Room>> GetAllClearAsync();
    }
}