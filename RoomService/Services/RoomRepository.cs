using HotelService.Interfaces;
using HotelService.Models;
using RoomService.Models;

namespace HotelService.Services
{
    public class RoomRepository : IRoomsRepo<Room, int>
    {
        private readonly RoomContext _roomContext;

        public RoomRepository(RoomContext roomContext)
        {
            _roomContext = roomContext;
        }
        // The Add(room item) takes room object as parameter and adds it
        public Room Add(Room item)
        {
            _roomContext.Add(item);
            _roomContext.SaveChanges();
            return item;
        }
        // The Delete(int Key) takes the Key as parameter and returns the deleted room object
        public Room Delete(int key)
        {
            // fetching room object that matches the key
            var room = _roomContext.Rooms.SingleOrDefault(r => r.Id == key);
            if (room != null)
            {
                _roomContext.Remove(room);
                _roomContext.SaveChanges();
                return room;
            }
            return null;
        }
        // The Get(int key) takes key as parameter and returns the room object that matches the key
        public Room Get(int key)
        {
            // fetching room object that matches the key
            var room = _roomContext.Rooms.SingleOrDefault(r => r.Id == key);
            if (room != null)
                return room;
            return null;

        }
        // The GetAll() returns collection of room objects
        public ICollection<Room> GetAll()
        {
            //fetching room objects and returning it as collection
            return _roomContext.Rooms.ToList();
        }
        // The Update(Room item) updates the room object and returns the updated room object 
        public Room update(Room item)
        {
            //fetching the room object that matches with given item id
            var room = Get(item.HotelId);
            if (room != null)
            {
                room.RoomNumber=item.RoomNumber;
                room.RoomType=item.RoomType;
                room.HotelId=item.HotelId;
                _roomContext.Add(room);
                _roomContext.SaveChanges();
                return room;


            }
            return null;
        }
    }
}
