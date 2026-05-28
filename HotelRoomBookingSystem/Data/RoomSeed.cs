using HotelRoomBookingSystem.Models;

namespace HotelRoomBookingSystem.Data
{
    public static class RoomSeed
    {
        public static List<Room> GetRooms()
        {
            return new List<Room>
            {
                new Room { Id = 1, RoomNumber = "101", Type = "Single", PricePerNight = 500, IsBooked = false, Floor = 1 },
                new Room { Id = 2, RoomNumber = "102", Type = "Double", PricePerNight = 800, IsBooked = true, Floor = 1 },
                new Room { Id = 3, RoomNumber = "201", Type = "Suite", PricePerNight = 1500, IsBooked = false, Floor = 2 },
                new Room { Id = 4, RoomNumber = "202", Type = "Single", PricePerNight = 550, IsBooked = true, Floor = 2 },
                new Room { Id = 5, RoomNumber = "301", Type = "Double", PricePerNight = 900, IsBooked = false, Floor = 3 },
                new Room { Id = 6, RoomNumber = "302", Type = "Suite", PricePerNight = 1700, IsBooked = true, Floor = 3 },
                new Room { Id = 7, RoomNumber = "401", Type = "Single", PricePerNight = 600, IsBooked = false, Floor = 4 },
                new Room { Id = 8, RoomNumber = "402", Type = "Double", PricePerNight = 950, IsBooked = false, Floor = 4 }
            };
        }
    }
}