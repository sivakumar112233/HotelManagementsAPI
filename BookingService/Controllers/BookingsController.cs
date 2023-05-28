using BookingService.Interfaces;
using BookingService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
   
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class BookingsController: ControllerBase
    {
        private readonly IBookingsRepo<Booking, int> _repo;
        private readonly IBookingService<Booking, int> _service;
       
        public BookingsController(IBookingsRepo<Booking,int>repo,IBookingService<Booking,int>service) {
            _repo=repo;
            _service=service;
        }

        [HttpPost]
        // The BookHotel(Booking booking) takes booking object and adds
        public IActionResult BookHotel(Booking booking)
        {
            try
            {
                // fetching bookings data
                var bookings = _service.BookReservation(booking);
                if (bookings != null)
                    return Ok(bookings);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("server not found");
        }
        [HttpDelete]
       // The  CancelBooking(int Index) method takes Index as parameter\
       // and checks for matching index and deletes it and returns deleted object
        public IActionResult CancelBooking(int Index)
        {
            try
            {
                // fetching bookings data
                var cancelBooking = _service.CancelReservation(Index);
                if (cancelBooking != null)
                    return Ok(cancelBooking);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("SERVER NOT FOUND");
        }
        [HttpGet]
        // The Bookings() method returns all booking details
        public IActionResult Bookings()
        {
           var allbookins=_repo.GetAll().ToList();
            if (allbookins!=null)
                return Ok(allbookins);
            return BadRequest("No data found");
        }
        // The GetRoomsByHotelName(string hotelName) method filters by name and provide matched hotel details
        // by communicating with hotelService api and roomService api
        [HttpGet("hotels/byName/{hotelName}")]
        public async Task<IActionResult> GetRoomsByHotelName(string hotelName)
        {
            try
            {
                // Create an instance of HttpClient
                var httpClient = new HttpClient();

                // Make a GET request to the Hotel API to fetch hotels
                var hotelResponse = await httpClient.GetAsync("http://localhost:5161/Hotel");

                if (!hotelResponse.IsSuccessStatusCode)
                {
                    return BadRequest("Error occurred while fetching hotels from Hotel API.");
                }

                // Deserialize the response content to a collection of Hotel objects
                var hotels = await hotelResponse.Content.ReadFromJsonAsync<List<HotelDTO>>();

                // Filter the hotels based on the provided hotelName
                var filteredHotels = hotels.Where(h => h.Name == hotelName).ToList();

                if (filteredHotels.Count == 0)
                {
                    return NotFound("No rooms found for the provided hotel name.");
                }

                // Fetch the rooms from the Room API
                var roomResponse = await httpClient.GetAsync("http://localhost:5147/Room");

                if (!roomResponse.IsSuccessStatusCode)
                {
                    return BadRequest("Error occurred while fetching rooms from Room API.");
                }

                // Deserialize the response content to a collection of Room objects
                var rooms = await roomResponse.Content.ReadFromJsonAsync<List<RoomsDTO>>();

                // Filter the rooms based on the hotel IDs of the filtered hotels
                var filteredRooms = rooms.Where(r => filteredHotels.Any(h => h.HotelId == r.HotelId)).ToList();

                return Ok(filteredRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
