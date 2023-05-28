using System.Linq;
using HotelService.Interfaces;
using HotelService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoomService.Models;

namespace HotelService.Controllers

{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IRoomsRepo<Room, int> _repo;
        private readonly IRoomsService<Room, int> _service;
       

        public RoomController(IRoomsRepo<Room, int> repo, IRoomsService<Room, int> service)
        {
            _repo = repo;
            _service = service;
           
        }
        [HttpPost]
        // The AddRoom(Room room) adds room object to database and returns it
        public IActionResult AddRoom(Room room)
        {
            try
            {
                var rooms = _service.AddingData(room);
                if (rooms != null)
                    return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpPut]
        // The EditRoom(Room room) takes room object as parameter updates it and returns it
        public IActionResult EditRoom(Room room)
        {
            try
            {
                var editedRoom= _service.UpdatingData(room);
                if (editedRoom != null)
                    return Ok(editedRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpDelete]
        // The DeletedRoom(int id) method takes int as parameter and returns Deletes the room that matches 
        // and returns it
        public IActionResult DeletedRoom(int id)
        {
            try
            {
                //fetching the room data
                var deletedRoom = _service.DeletingData(id);
                if (deletedRoom != null)
                    return Ok(deletedRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpGet]
        // The  GetRooms() method returns all rooms 
        public IActionResult GetRooms()
        {
            try
            {
                // fetching room data
                var allRooms = _service.ViewingData();
                if (allRooms != null)
                    return Ok(allRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        [HttpGet("id")]
        // The GetSingleRoom(int id) method takes id as parameter and returns room object that matches
        public IActionResult GetSingleRoom(int id)
        {
            try
            {
                // fetching room data
                var Rooms = _service.ViewSingularData(id);
                if (Rooms != null)
                    return Ok(Rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");
        }
        // The GetRoomsSortByPrice(double max,double min) methods gets records the price between min and max
        [HttpGet("ByPrice")]
        public IActionResult GetRoomsSortByPrice(double max,double min) {

            try
            {
                // fetching all rooms details
                var allRooms = _service.ViewingData();
                var SpecificRooms=allRooms.Where(a=>a.Price>=min &&a.Price<=max);
                return Ok(SpecificRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("internal server error");

        }

       





    }
}
