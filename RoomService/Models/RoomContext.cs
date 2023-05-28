using HotelService.Models;
using Microsoft.EntityFrameworkCore;

namespace RoomService.Models
{
    public class RoomContext:DbContext
    {
        public RoomContext(DbContextOptions options):base(options) { }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomNumber = "20A", RoomType = "AC", HotelId = 1, Price = 999, },
                new Room { Id = 2, RoomNumber = "20B", RoomType = "AC", HotelId = 1, Price = 555  },
                new Room { Id = 3, RoomNumber = "30A", RoomType = "NonAC", HotelId = 2, Price = 666  },
                new Room { Id = 4, RoomNumber = "30B", RoomType = "AC", HotelId = 2, Price = 2999 },
                new Room { Id = 5, RoomNumber = "40A", RoomType = "AC", HotelId = 3, Price = 4999 },
                new Room { Id = 6, RoomNumber = "40B", RoomType = "NonAC", HotelId = 3, Price = 1199 },
                new Room { Id = 7, RoomNumber = "50A", RoomType = "AC", HotelId = 4, Price = 3999 },
                new Room { Id = 8, RoomNumber = "50B", RoomType = "NonAC", HotelId = 4, Price = 1999 }



                ); 

        }
    }
}
