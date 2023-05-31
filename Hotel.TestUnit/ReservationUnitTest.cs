using HotelReservation.Core.Repository;
using HotelReservation.Core.Service;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Hotel.TestUnit
{
    public class ReservationUnitTest
    {
        [Fact]
        public async Task Test1Async()
        {
            Guid roomID = Guid.NewGuid();
            var guest = new Guest();
            var room1 = new Room()
            {
                Id = roomID,
                Name = "Room1"
            };
            var rooms = new List<Room>();
            rooms.Add(room1);
            var reservation = new Reservation() {
                Rooms = rooms,
                Start_Date = new DateTime(2022,12,1,10,0,0),
                End_Date =  new DateTime(2022, 12, 11, 10, 0, 0)
            };
            var reservations = new List<Reservation>();
            reservations.Add(reservation);
            var repo = new Mock<IReservationRepository>();
            repo.Setup(e => e.GetAllAsync()).ReturnsAsync(reservations);

            var service = new ReservationService(repo.Object, null, null);

            var result = await service.IsRooomAvailableAsync(Guid.NewGuid(), new DateTime(2022, 12, 1, 10, 0, 0), new DateTime(2022, 12, 11, 10, 0, 0));

            Assert.True(result);
        }
    }
}
