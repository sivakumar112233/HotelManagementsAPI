using Microsoft.EntityFrameworkCore;

namespace HotelService.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(

                new Hotel { HotelId = 1, Name = "oyo", Location = "Chennai" },
                new Hotel { HotelId = 2, Name = "Novatel", Location = "Bangalore" },
                new Hotel { HotelId = 3, Name = "yolo", Location = "Chennai" },
                new Hotel { HotelId = 4, Name = "standardFord", Location = "Bangalore" }



                );


        }




    }
}
