namespace HotelService.Models.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }
        public int HotelId { get; set; }
    }
}
