using HotelService.Interfaces;
using HotelService.Models;

namespace HotelService.Services
{
    public class HotelRepository : IHotelsRepo<Hotel, int>
    {
        private readonly HotelContext _hotelContext;
        // Taking data injection from HotelContext
        public HotelRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        // The Add(Hotel item) method takes Hotel object as parameter and adds 
        public Hotel Add(Hotel item)
        {
            _hotelContext.Add(item);
            _hotelContext.SaveChanges();
            return item;
        }


        // the Delete(int key) takes the key and deletes the Hotel object that matches and returns the deleted object
        public Hotel Delete(int key)
        {
            // fetching Hotel object that matches the key
            var hotel = _hotelContext.Hotels.SingleOrDefault(h => h.HotelId == key);
            if (hotel != null)
            {
                _hotelContext.Remove(hotel);
                _hotelContext.SaveChanges();
                return hotel;
            }
            return null;
        }
        // The Get(int key) takes key as parameter and returns the hotel object that matches the key
        public Hotel Get(int key)
        {
            // fetching Hotel object that matches the key
            var hotel = _hotelContext.Hotels.SingleOrDefault(h => h.HotelId == key);
            if (hotel != null)
                return hotel;
            return null;

        }
        // The GetAll() returns collection of Hotel objects
        public ICollection<Hotel> GetAll()
        {
            //fetching hotel objects and returning it as collection
            return _hotelContext.Hotels.ToList();
        }
        // The Update(Hotel item) updates the hotel object and returns the updated hotel object 
        public Hotel Update(Hotel item)
        {
            //fetching the hotel object that matches with given item id
            var hotel = Get(item.HotelId);
            if (hotel != null)
            {
                hotel.Name = item.Name;
                hotel.Location = item.Location;
                _hotelContext.Add(hotel);
                _hotelContext.SaveChanges();
                return hotel;


            }
            return null;
        }
    }
}
