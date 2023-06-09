using HotelReservation.Models.Enum;
using System;

namespace HotelReservation.Models.Attributes
{
    public class PermisionAttribute : Attribute
    {
        public PermisionAttribute(EUserType type)
        {
            Type = type;
        }

        public PermisionAttribute()
        {
            Type = EUserType.Admin | EUserType.Boss | EUserType.Employee;
        }

        public EUserType Type { get; }
    }
}