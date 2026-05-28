using HotelRoomBookingSystem.Data;
using HotelRoomBookingSystem.Services;
using HotelRoomBookingSystem.Models;

class Program
{
    static void Main()
    {
        var rooms = RoomSeed.GetRooms();
        var service = new RoomService(rooms);

        while (true)
        {
            ShowMenu();

            Console.Write("\nEnter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowRooms(service.GetAvailableRooms());
                    break;

                case "2":
                    ShowRooms(service.GetAllRooms());
                    break;

                case "3":
                    BookRoomFlow(service);
                    break;

                case "4":
                    var cheap = service.GetCheapestRoom();
                    Console.WriteLine($"\nCheapest Room: {cheap.RoomNumber} - {cheap.PricePerNight}");
                    Pause();
                    break;

                case "5":
                    Console.WriteLine($"\nBooked Rooms: {service.GetBookedCount()}");
                    Pause();
                    break;

                case "6":
                    Console.Write("\nEnter Type: ");
                    ShowRooms(service.GetRoomsByType(Console.ReadLine()));
                    break;

                case "7":
                    Console.WriteLine("Goodbye 👋");
                    return;

                case "8":
                    service.ShowStatistics();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    Pause();
                    break;
            }
        }
    }

    // =========== MENU ===============
    static void ShowMenu()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================");
        Console.WriteLine("   🏨 HOTEL ROOM SYSTEM");
        Console.WriteLine("====================================");
        Console.ResetColor();

        Console.WriteLine("1. Available Rooms");
        Console.WriteLine("2. All Rooms");
        Console.WriteLine("3. Book Room");
        Console.WriteLine("4. Cheapest Room");
        Console.WriteLine("5. Booked Count");
        Console.WriteLine("6. Search by Type");
        Console.WriteLine("7. Exit");
        Console.WriteLine("8. Dashboard");
        Console.WriteLine("====================================");
    }

    // ================= BOOK FLOW =================
    static void BookRoomFlow(RoomService service)
    {
        Console.Clear();

        var available = service.GetAvailableRooms();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("===== AVAILABLE ROOMS =====");
        Console.ResetColor();

        if (!available.Any())
        {
            Console.WriteLine("No available rooms!");
            Pause();
            return;
        }

        for (int i = 0; i < available.Count; i++)
        {
            var r = available[i];
            Console.WriteLine($"{i + 1}. Room {r.RoomNumber} | {r.Type} | {r.PricePerNight} | Floor {r.Floor}");
        }

        Console.Write("\nSelect room number: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int index) || index < 1 || index > available.Count)
        {
            Console.WriteLine("Invalid selection!");
            Pause();
            return;
        }

        var selected = available[index - 1];

        service.BookRoom(selected.RoomNumber);

        Pause();
    }

    // ============= TABLE ===============
    static void ShowRooms(List<Room> rooms)
    {
        Console.Clear();

        Console.WriteLine("====================================");
        Console.WriteLine("         ROOMS LIST");
        Console.WriteLine("====================================");

        foreach (var r in rooms)
        {
            Console.ForegroundColor = r.IsBooked ? ConsoleColor.Red : ConsoleColor.Green;

            Console.WriteLine($"{r.RoomNumber} | {r.Type} | {r.PricePerNight} | {(r.IsBooked ? "BOOKED" : "FREE")}");

            Console.ResetColor();
        }

        Console.WriteLine("==================================");

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}