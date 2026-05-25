using System;
using System.Collections.Generic;
using System.Linq;
using HotelRoomBookingSystem.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========== HOTEL ROOM BOOKING SYSTEM ==========\n");
        Console.ResetColor();

        // Sample Data
        List<Room> rooms = new List<Room>
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

        // 1. Available Rooms
        var availableRooms = rooms.Where(r => !r.IsBooked).ToList();
        Console.WriteLine("AVAILABLE ROOMS:");
        PrintTable(availableRooms);

        // 2. Room Numbers only
        Console.WriteLine("\nROOM NUMBERS:");
        var roomNumbers = rooms.Select(r => r.RoomNumber);
        foreach (var num in roomNumbers)
            Console.WriteLine(num);

        // 3. First available Suite
        var firstSuite = rooms.FirstOrDefault(r => r.Type == "Suite" && !r.IsBooked);
        Console.WriteLine("\nFIRST AVAILABLE SUITE:");
        if (firstSuite != null)
            Console.WriteLine($"Room {firstSuite.RoomNumber} - {firstSuite.Type}");

        // 4. Sort by price
        var sorted = rooms.OrderBy(r => r.PricePerNight).ToList();
        Console.WriteLine("\nROOMS SORTED BY PRICE:");
        PrintTable(sorted);

        // 5. Count booked rooms
        var bookedCount = rooms.Count(r => r.IsBooked);
        Console.WriteLine($"\nBOOKED ROOMS COUNT: {bookedCount}");

        // 6. Average price
        var avgPrice = rooms.Average(r => r.PricePerNight);
        Console.WriteLine($"AVERAGE PRICE: {avgPrice}");

        // 7. Most expensive room
        var maxRoom = rooms.OrderByDescending(r => r.PricePerNight).First();
        Console.WriteLine($"\nMOST EXPENSIVE ROOM: Room {maxRoom.RoomNumber} - {maxRoom.Type}");

        // 8. Rooms on specific floor
        var floorRooms = rooms.Where(r => r.Floor == 4).ToList();
        Console.WriteLine("\nROOMS ON FLOOR 4:");
        PrintTable(floorRooms);

        // 9. Search by type
        var singleRooms = rooms.Where(r => r.Type == "Single").ToList();
        Console.WriteLine("\nSINGLE ROOMS:");
        PrintTable(singleRooms);

        // 10. Group by type
        Console.WriteLine("\nGROUPED BY TYPE:");
        var grouped = rooms.GroupBy(r => r.Type);

        foreach (var group in grouped)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var r in group)
                Console.WriteLine($"Room {r.RoomNumber}");
        }

        // 11. Available sorted
        var availableSorted = rooms.Where(r => !r.IsBooked)
                                   .OrderBy(r => r.PricePerNight)
                                   .ToList();

        Console.WriteLine("\nAVAILABLE ROOMS SORTED:");
        PrintTable(availableSorted);

        // 12. Cheapest room
        var cheapest = rooms.OrderBy(r => r.PricePerNight).First();
        Console.WriteLine($"\nCHEAPEST ROOM: {cheapest.RoomNumber} - {cheapest.PricePerNight}");

        // 13. Price > 1000
        var expensive = rooms.Where(r => r.PricePerNight > 1000).ToList();
        Console.WriteLine("\nROOMS PRICE > 1000:");
        PrintTable(expensive);

    }

    // Table Display Method
    static void PrintTable(List<Room> rooms)
    {
        Console.WriteLine("=======================================================");
        Console.WriteLine("| No  | Type     | Price      | Booked   | Floor |");
        Console.WriteLine("=======================================================");

        foreach (var r in rooms)
        {
            Console.WriteLine(
                $"| {r.RoomNumber,-3} | {r.Type,-8} | {r.PricePerNight,-10} | {r.IsBooked,-6} | {r.Floor,-5} |");
        }

        Console.WriteLine("==============================================================");
    }
}