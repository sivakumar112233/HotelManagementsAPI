namespace HotelService.Models.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string? User { get; set; }



        public string? Status { get; set; }
    }
}
