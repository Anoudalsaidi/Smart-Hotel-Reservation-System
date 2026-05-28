namespace HotelRoomBookingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public bool IsBooked { get; set; }
        public int Floor { get; set; }
    }
}