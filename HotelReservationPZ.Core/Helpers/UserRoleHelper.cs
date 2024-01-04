using HotelReservation.Models.Enum;
using System;

namespace HotelReservation.Core.Helpers
{
    public static class UserRoleHelper
    {
        public static string Admin = $"{EUserType.Admin}";

        public static string Employee = $"{EUserType.Employee}";
        public static string Boss = $"{EUserType.Boss}";
        public static string None = $"{EUserType.None}";


    }
}