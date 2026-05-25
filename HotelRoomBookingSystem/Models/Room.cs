using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomBookingSystem.Models
{
    
        public class Room
        {
            public int Id { get; set; }

            public string RoomNumber { get; set; }

            public string Type { get; set; }

            public double PricePerNight { get; set; }

            public bool IsBooked { get; set; }

            public int Floor { get; set; }
        }
    }

