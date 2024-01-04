using HotelReservation.Core.Exeptions;
using HotelReservation.Core.Repository;
using HotelReservation.Core.ViewModels;
using HotelReservation.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public class UserService : IUserService
    {
        #region Private Properties

        /// <summary>
        /// Repository of room type
        /// </summary>
        private readonly IUsersRepository _userRepository;

        private readonly UserManager<IdentityUser> _userMenager;

        #endregion

        #region Constructors

        /// <summary>
        /// Deafult constructor
        /// </summary>
        /// <param name="roomTypeRepository">Repository of room typen</param>
        public UserService(IUsersRepository userRepository, UserManager<IdentityUser> userMenager)
        {
            _userRepository = userRepository;
            _userMenager = userMenager;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method to get room by id 
        /// </summary>
        /// <param name="id">Id of room</param>
        /// <returns></returns>
        public async Task<IdentityUser> GetAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveAsync();
        }

        /// <summary>
        /// Method to get all types of room
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Method to create a Room
        /// </summary>
        /// <param name="form">Created room</param>
        /// <param name="wwwpath">Path to savea a image</param>
        /// <returns></returns>
        public async Task<IdentityUser> CreateAsync(IdentityUser user, string passworld)
        {
            await _userMenager.CreateAsync(user, passworld);
            return user;
        }

        /// <summary>
        /// Method to update room
        /// </summary>
        /// <param name="item">Room to update</param>
        /// <returns></returns>
        public async Task UpdateAsync(IdentityUser item)
        {
            _userRepository.Update(item);
            await _userRepository.SaveAsync();
        }

        #endregion

    }
}
