using HotelReservation.Core.Exeptions;
using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class ReservationService : IReservationService
    {
        #region Private Properties

        /// <summary>
        /// Repository of reservation
        /// </summary>
        private readonly IReservationRepository _reservationRepository;

        /// <summary>
        /// Repository of rooms
        /// </summary>
        private readonly IRoomsRepository _roomsRepository;

        /// <summary>
        /// Repository of hotel
        /// </summary>
        private readonly IHotelsRepository _hotelsRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Deafult constructor
        /// </summary>
        /// <param name="reservationRepository">Repository of reservation</param>
        /// <param name="roomsRepository">Repository of room</param>
        /// <param name="hotelsRepository">Repository of hotel</param>
        public ReservationService(
            IReservationRepository reservationRepository,
            IRoomsRepository roomsRepository,
            IHotelsRepository hotelsRepository)
        {
            _reservationRepository = reservationRepository;
            _roomsRepository = roomsRepository;
            _hotelsRepository = hotelsRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to take a reservation
        /// </summary>
        /// <param name="id">Id of reservation</param>
        /// <returns></returns>
        public async Task<Reservation> GetReservation(Guid id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Method to book reservation
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public async Task<Reservation> BookAsync(ReservationFormViewModel form)
        {

            if (form == null) throw new DataExeption("Pusty formularz");
            

            Room room = await _roomsRepository.GetByIdAsync(form.RoomId);
            if (room == null)
            {
                throw new DataExeption("Nie znaleziono pokoju");
            }

            Hotel hotel = await _hotelsRepository.GetByIdAsync(room.HotlelId);
            if (hotel == null)
            {
                throw new DataExeption("Nie znaleziono hotelu");
            }

            Dictionary<string, string> erros = new Dictionary<string, string>();

            if (form.StartDate > form.EndDate)
                throw new ErrorModelExeption(nameof(form.StartDate), "Błędna data zameldowania");


            if (form.CountOfRoom == 0)
                throw new ErrorModelExeption(nameof(form.CountOfRoom), "Liczba pokoi nie może być pusta");

            if (form.StartDate.Hour < hotel.HoursCheckInFrom || form.StartDate.Hour > hotel.HoursCheckInTo - 1)
                erros.Add(nameof(form.StartDate), $"Zameldowanie możliwe w godzinach {hotel.HoursCheckInFrom} - {hotel.HoursCheckInTo}");

            if (form.EndDate.Hour < hotel.HoursCheckOutFrom || form.EndDate.Hour > hotel.HoursCheckOutTo - 1)
                erros.Add(nameof(form.EndDate), $"Wymeldowanie możliwe w godzinach {hotel.HoursCheckOutFrom} - {hotel.HoursCheckOutTo}");

            if (form.CountOfAdults + form.CountOfChildren > (room.MaxQuantityOfPeople) * form.CountOfRoom)
                erros.Add(nameof(form.CountOfAdults), $"Maksymalna ilosć osób w pokoju/ach {(room.MaxQuantityOfPeople) * form.CountOfRoom} ");

            if (string.IsNullOrEmpty(form.FirstName))
                erros.Add(nameof(form.FirstName), $"Podaj imię");

            if (string.IsNullOrEmpty(form.LastName))
                erros.Add(nameof(form.LastName), $"Podaj nazwisko");

            if (string.IsNullOrEmpty(form.Phone))
                erros.Add(nameof(form.Phone), $"Podaj numer telefonu");

            if (string.IsNullOrEmpty(form.Country))
                erros.Add(nameof(form.Country), $"Wpisz kraj");

            if (string.IsNullOrEmpty(form.Street))
                erros.Add(nameof(form.Street), $"Wpisz ulice");

            if (string.IsNullOrEmpty(form.StreetNumber))
                erros.Add(nameof(form.StreetNumber), $"Wpisz numer ulicy");

            if (string.IsNullOrEmpty(form.ZipCode))
                erros.Add(nameof(form.ZipCode), $"Wpisz kod pocztowy");

            if (string.IsNullOrEmpty(form.City))
                erros.Add(nameof(form.City), $"Wpisz miejscowosć");

            if (erros.Count > 0)
                throw new ErrorModelExeption(erros);

            if (!(await IsRooomAvailableAsync(room.Id, form.StartDate, form.EndDate)))
                throw new ErrorModelExeption(
                    nameof(form.StartDate), 
                    $"Wybrany pokój jest zajęty pomiędzy {form.StartDate.ToShortDateString()} a {form.EndDate.ToShortDateString()}");


            Address address = new Address()
            {
                Id = Guid.NewGuid(),
                Country = form.Country,
                Street = form.Street,
                StreetNumber = form.StreetNumber,
                ZipCode = form.ZipCode,
                City = form.City
            };

            Guest gust = new Guest()
            {
                Id = Guid.NewGuid(),
                First_Name = form.FirstName,
                Last_Name = form.LastName,
                Email = form.Email,
                Phone = form.Phone,
                Addres = address,
                AddresId = address.Id,
            };

            Reservation reservation = new Reservation()
            {
                Id = Guid.NewGuid(),
                Start_Date = form.StartDate,
                End_Date = form.EndDate,
                CountOfAdults = form.CountOfAdults,
                CountOfRoom = form.CountOfRoom,
                CountOfChildren = form.CountOfChildren,
                Details = form.Details,
                Rooms = new List<Room>(),
                Guest = gust,
                Total_Price = getPrice(room, form.CountOfRoom, form.StartDate, form.EndDate)
            };


            reservation.Rooms.Add(room);
            await _reservationRepository.InsertAsync(reservation);
            await _reservationRepository.SaveAsync();


            return reservation;
        }

        /// <summary>
        /// Method to check if Room is avilable
        /// </summary>
        /// <param name="roomId">Id of room</param>
        /// <param name="check_in">Date of check in</param>
        /// <param name="check_out">Date of check out</param>
        /// <returns></returns>
        public async Task<bool> IsRooomAvailableAsync(Guid roomId, DateTime check_in, DateTime check_out)
        {
            foreach(Reservation reserv in await _reservationRepository.GetAllAsync())
            {
                foreach(Room room in reserv.Rooms)
                {
                    if(room.Id == roomId)
                    {
                        if (check_in >= reserv.Start_Date && check_in <= reserv.End_Date)
                            return false;

                        if (check_out >= reserv.Start_Date && check_out <= reserv.End_Date)
                            return false;

                        if (check_in < reserv.Start_Date && check_out > reserv.End_Date)
                            return false;

                        if (check_in.Year == reserv.Start_Date.Year
                            && check_in.Month == reserv.Start_Date.Month
                            && check_in.Day == reserv.Start_Date.Day)
                            return false;

                        if (check_in.Year == reserv.End_Date.Year
                            && check_in.Month == reserv.End_Date.Month
                            && check_in.Day == reserv.End_Date.Day)
                            return false;

                        if (check_out.Year == reserv.Start_Date.Year
                            && check_out.Month == reserv.Start_Date.Month
                            && check_out.Day == reserv.Start_Date.Day)
                            return false;

                        if (check_out.Year == reserv.End_Date.Year
                            && check_out.Month == reserv.End_Date.Month
                            && check_out.Day == reserv.End_Date.Day)
                            return false;

                    }
                }
            }
            return true;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to get price to reservation
        /// </summary>
        /// <param name="room">Room of reservation</param>
        /// <param name="CountOfRoom">Count of rooms</param>
        /// <param name="start">Date of check in</param>
        /// <param name="end">Date of check out</param>
        /// <returns></returns>
        private double getPrice(Room room, int CountOfRoom, DateTime start, DateTime end)
        {
            int days = (int)(end - start).TotalDays;

            return (room.Price * room.Discount) * CountOfRoom * days;
        }

        #endregion
    }


}
