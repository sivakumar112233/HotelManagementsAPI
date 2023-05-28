using System.Net.Http;
using HotelService.Interfaces;
using HotelService.Models;
using HotelService.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private readonly IHotelsRepo<Hotel, int> _repo;
        private readonly IHotelsService<Hotel, int> _service;
        private readonly HttpClient httpClient;

        public HotelController(IHotelsRepo<Hotel, int> repo, IHotelsService<Hotel, int> service)
        {
            _repo = repo;
            _service = service;
            httpClient = new HttpClient();

        }
        [HttpPost]
        // The AddHotel(Hotel hotel) method adds hotel object to database and returns the added object
        public IActionResult AddHotel(Hotel hotel)
        {
            try
            {
                // fetching Data
                var hotels = _service.AddingData(hotel);
                if (hotels != null)
                    return Ok(hotels);
            }
            catch (Exception ex)
            {
                // handling the expection
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpPut]
        // The EditHotel(Hotel hotel) edits the hotel object data
        public IActionResult EditHotel(Hotel hotel)
        {
            try
            {
                // fetching the hotel data
                var editedHotel = _service.UpdatingData(hotel);
                if (editedHotel != null)
                    return Ok(editedHotel);
            }
            catch (Exception ex)
            {
                // handling the exception
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpDelete]
        //DeleteHotel(int id) deletes the hotel object from database
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                //fetching hotel object
                var deletedHotel = _service.DeletingData(id);
                if (deletedHotel != null)
                    return Ok(deletedHotel);
            }
            catch (Exception ex)
            {
                // handling the exception

                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpGet]
        // The GetHotel() method returns all hotel objects
        public IActionResult GetHotel()
        {
            try
            {
                var allHotels = _service.ViewingData();
                if (allHotels != null)
                    return Ok(allHotels);
            }
            catch (Exception ex)
            {
                // handling the exception
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpGet("id")]
        // The GetSingleHotel(int id) gets hotel details that matches with id
        public IActionResult GetSingleHotel(int id)
        {
            try
            {
                var hotel = _service.ViewSingularData(id);
                if (hotel != null)
                    return Ok(hotel);
            }
            catch (Exception ex)
            {
                // handling the exception
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpGet("{hotelId}/rooms")]
        // The  GetRoomsByHotel(int hotelId) method gets all the room details that are having from same hotel 
        // by Communicating with RoomsApi
        public async Task<IActionResult> GetRoomsByHotel(int hotelId)
        {
            try
            {
               

                // Make a GET request to the RoomController API to fetch all rooms
                var roomsResponse = await httpClient.GetAsync("http://localhost:5147/Rooms");

                if (!roomsResponse.IsSuccessStatusCode)
                {
                    var errorMessage = $"Error occurred while fetching rooms from Rooms API. Status Code: {roomsResponse.StatusCode}";
                    return BadRequest(errorMessage);
                }

                // Deserialize the response content to a collection of RoomDTO
                var roomDTOs = await roomsResponse.Content.ReadFromJsonAsync<List<RoomDTO>>();

                // Filter the rooms based on the provided hotelId
                var filteredRooms = roomDTOs.Where(r => r.HotelId == hotelId).ToList();

                return Ok(filteredRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("AvailableRoomsCount")]
        // The GetNotBookedRoomsCount() methods gets all the rooms that are avialable for booking 
        // by communicating with both rooms api and bookings api
        public async Task< IActionResult> GetNotBookedRoomsCount()
        {
            try
            {
                

                // Fetch all rooms from the RoomService API
                var roomsResponse = await httpClient.GetAsync("http://localhost:5147/Room");

                if (roomsResponse.IsSuccessStatusCode)
                {
                    var roomsJson = await roomsResponse.Content.ReadAsStringAsync();
                    var rooms = JsonConvert.DeserializeObject<List<RoomDTO>>(roomsJson);

                    // Fetch all bookings from the Bookings API
                    var bookingsResponse = await httpClient.GetAsync("http://localhost:5262/Bookings");

                    if (bookingsResponse.IsSuccessStatusCode)
                    {
                        var bookingsJson = await bookingsResponse.Content.ReadAsStringAsync();
                        var bookings = JsonConvert.DeserializeObject<List<BookingDTO>>(bookingsJson);

                        // Get the list of room IDs that are booked
                        var bookedRoomIds = bookings.Select(booking => booking.RoomId);

                        // Calculate the count of not booked rooms
                        var notBookedRoomsCount = rooms.Count(room => !bookedRoomIds.Contains(room.Id));

                        return Ok(notBookedRoomsCount);
                    }
                    else
                    {
                        // Handle error response from Bookings API (failed to get booking data)
                        var errorMessage = await bookingsResponse.Content.ReadAsStringAsync();
                        return BadRequest(errorMessage);
                    }
                }
                else
                {
                    // Handle error response from RoomService API (failed to get room data)
                    var errorMessage = await roomsResponse.Content.ReadAsStringAsync();
                    return BadRequest(errorMessage);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}






    


    

