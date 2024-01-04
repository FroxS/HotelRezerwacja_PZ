using HotelReservation.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservation.Core.Service
{
    public interface IUserService
    {
        /// <summary>
        /// Method to get all users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IdentityUser>> GetAllAsync();

        /// <summary>
        /// Method to get user by id 
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns></returns>
        Task<IdentityUser> GetAsync(Guid id);

        Task<IdentityUser> CreateAsync(IdentityUser user, string passworld);
        Task UpdateAsync(IdentityUser user);
        Task DeleteAsync(Guid i);
    }
}