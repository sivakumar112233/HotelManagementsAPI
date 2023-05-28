using Microsoft.EntityFrameworkCore;
using BookingService.Models;

namespace BookingService.Models
{
    public class BookingContext:DbContext
    {
        public BookingContext(DbContextOptions options ):base(options) { }
        public DbSet<Booking> Bookings { get; set; }
       protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id=1,RoomId=1,user="ram",Status="Confirmed"},
                new Booking { Id = 2, RoomId = 2, user = "raju", Status = "Confirmed" }

                );
        }
    }
}
