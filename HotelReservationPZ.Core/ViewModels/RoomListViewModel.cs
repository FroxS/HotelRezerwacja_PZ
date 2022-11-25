﻿using System;

namespace HotelReservation.Core.ViewModels
{
    public class RoomListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }
    }
}
