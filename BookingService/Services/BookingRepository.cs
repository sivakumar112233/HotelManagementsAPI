using BookingService.Interfaces;
using BookingService.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookingService.Services
{
    public class BookingRepository : IBookingsRepo<Booking, int>
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context) { 
            _context=context;
        }
        // The Add(room item) takes Booking  object as parameter and adds it
        public Booking Add(Booking item)
        {
            _context.Add(item);
            return item;    
        }
        // The Delete(int Key) takes the Key as parameter and returns the deleted Booking object
        public Booking Delete(int key)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.Id == key);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
            return booking;
        }

        // The Get(int key) takes key as parameter and returns the Booking object that matches the key
        public Booking Get(int key)
        {
           return _context.Bookings.SingleOrDefault(b=>b.Id==key); 
        }
        // The GetAll() returns collection of Booking  objects
        public ICollection<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        // The Update(item Booking ) updates the Booking object and returns the updated Booking object 
        public Booking Update(Booking item)
        {
            var Bookings = Get(item.Id);
            if (Bookings!=null)
            {
             
              Bookings.Status=item.Status;
              _context.SaveChanges();
                return item;

            }
            return null;
            
        }
    }
}
