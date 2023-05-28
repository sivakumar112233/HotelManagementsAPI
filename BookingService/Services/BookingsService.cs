using BookingService.Interfaces;
using BookingService.Models;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace BookingService.Services
{
    public class BookingsService : IBookingService<Booking,int>
    {
        private IBookingsRepo<Booking,int> _bookingsRepo;

        public BookingsService(IBookingsRepo<Booking,int>bookingsRepo) { 
            _bookingsRepo=bookingsRepo;
        }


        // The BookReservation(Booking item) takes booking object and adds
        public Booking BookReservation(Booking item)
        {
           var booking= _bookingsRepo.Get(item.Id);
            if (booking == null)
            {
                return _bookingsRepo.Add(item);

            }
            // it object is not present throwing custom expections
            throw new Exception("Already the rom is booked");
        }
        // The CancelReservation(int id) takes id and finds matched id ,deltes the object that 
        // matches and returns it

        public Booking CancelReservation(int id)
        {
            var booking = _bookingsRepo.Delete(id);
            if (booking != null)
            {
                return booking;
            }
            throw new Exception("you have not booked");
        }
    }
}
