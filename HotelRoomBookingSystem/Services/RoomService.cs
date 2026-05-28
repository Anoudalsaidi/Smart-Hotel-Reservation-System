using HotelRoomBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingSystem.Services
{
    public class RoomService
    {
        private readonly List<Room> _rooms;

        public RoomService(List<Room> rooms)
        {
            _rooms = rooms ?? new List<Room>();
        }

        public List<Room> GetAllRooms() => _rooms;

        public List<Room> GetAvailableRooms()
        {
            return _rooms.Where(r => !r.IsBooked).ToList();
        }

        public List<Room> GetRoomsByType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return new List<Room>();

            return _rooms.Where(r =>
                r.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Room GetCheapestRoom()
        {
            return _rooms.OrderBy(r => r.PricePerNight).FirstOrDefault();
        }

        public int GetBookedCount()
        {
            return _rooms.Count(r => r.IsBooked);
        }

        // 🔥 Booking
        public void BookRoom(string roomNumber)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ResetColor();
                return;
            }

            var room = _rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Room not found!");
                Console.ResetColor();
                return;
            }

            if (room.IsBooked)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Room already booked!");
                Console.ResetColor();
                return;
            }

            room.IsBooked = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Room {roomNumber} booked successfully ✔");
            Console.ResetColor();
        }

        // 🔥 Dashboard
        public void ShowStatistics()
        {
            Console.Clear();

            int total = _rooms.Count;
            int booked = _rooms.Count(r => r.IsBooked);
            int available = total - booked;
            var avgPrice = _rooms.Average(r => r.PricePerNight);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===== DASHBOARD =====");
            Console.ResetColor();

            Console.WriteLine($"Total Rooms     : {total}");
            Console.WriteLine($"Booked Rooms    : {booked}");
            Console.WriteLine($"Available Rooms : {available}");
            Console.WriteLine($"Average Price   : {avgPrice:F2}");

            Console.WriteLine("=====================");

            Console.ReadKey();
        }
    }
}