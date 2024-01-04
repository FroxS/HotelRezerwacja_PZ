using HotelReservation.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace HotelReservation.Core.Repository
{    public interface IUsersRepository :  IBaseRepository<IdentityUser>
    {
    }
}