using HotelService.Interfaces;
using HotelService.Models;

namespace HotelService.Services
{
    public class RoomsServices : IRoomsService<Room, int>
    {
        private readonly IRoomsRepo<Room, int> _roomsRepo;

        public RoomsServices(IRoomsRepo<Room, int> roomsRepo)
        {
            _roomsRepo = roomsRepo;
        }
        // The AddingData(Room item) takes room object as parameter and adds
        public Room AddingData(Room item)
        {
            var room= _roomsRepo.Get(item.HotelId);
            if (room == null)
                return _roomsRepo.Add(item);
            // if no object return custom Exception
            throw new Exception("room already present");

        }
        // The DeletingData(int key )takes Key as parameter type of int
        // and deletes the room object that matches and returns it
        public Room DeletingData(int key)
        {
            var room = _roomsRepo.Delete(key);
            if (room != null)
                return room;
            // if no object return custom Exception
            throw new Exception("no room present");
        }
        // The UpdatingData(Room item) method updates the Room object and returns it

        public Room UpdatingData(Room item)
        {
            var room = _roomsRepo.Update(item);
            if (room != null)
                return room;
            // if no object return custom Exception
            throw new Exception("no room present");
        }

        // The ViewingData() method returns collection of room object as list
        public ICollection<Room> ViewingData()
        {
            //fetching room objects from GetAll()
            var rooms = _roomsRepo.GetAll();
            if (rooms != null)
                return rooms.ToList();
            // if no object return custom Exception
            throw new Exception("rooms are empty");
        }
        // The ViewSingularData(int key) takes key as parameter and returns matched room object
        public Room ViewSingularData(int key)
        {
            //  fecthing room object
            var room = _roomsRepo.Get(key);
            if (room != null)
                return room;
            // if no object return custom Exception
            throw new Exception("no hotel with that id present");
        }
    }
}
