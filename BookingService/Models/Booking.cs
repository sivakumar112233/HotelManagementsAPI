using Microsoft.AspNetCore.Routing.Constraints;

namespace BookingService.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string user { get ; set; }   

        

        public string Status { get; set; }

    }
}
