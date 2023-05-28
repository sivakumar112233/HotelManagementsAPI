using System.ComponentModel.DataAnnotations;
using HotelService.Interfaces;
using HotelService.Models;

namespace HotelService.Services
{
    public class HotelsServices : IHotelsService<Hotel, int>
    {
        private readonly IHotelsRepo<Hotel, int> _hotelsRepo;

        // taking IHotelsRepo as injection
        public HotelsServices(IHotelsRepo<Hotel, int> hotelsRepo)
        {
            _hotelsRepo = hotelsRepo;
        }
        // The AddingData(Hotel item) takes hotel object as parameter and adds
        public Hotel AddingData(Hotel item)
        {
            //checking whether the object already present or not
            var hotel = _hotelsRepo.Get(item.HotelId);
            if (hotel == null)
                return _hotelsRepo.Add(item);
            // if no object return custom Exception
            throw new Exception("hotel already present");

        }
         
        // The DeletingData(int key )takes Key as parameter type of int
        // and deletes the hotel object that matches and returns it
        
        public Hotel DeletingData(int key)
        {
            var hotel = _hotelsRepo.Delete(key);
            if (hotel != null)
                return hotel;
            // if no object return custom Exception
            throw new Exception("no hotel present");
        }

        // The UpdatingData(Hotel item) method updates the hotel object and returns it
        public Hotel UpdatingData(Hotel item)
        {
            var hotel = _hotelsRepo.Update(item);
            if (hotel != null)
                return hotel;
            // if no object return custom Exception
            throw new Exception("no hotel present");
        }
        // The ViewingData() method returns collection of hotel object as list
        public ICollection<Hotel> ViewingData()
        {
            //fetching hotel objects from GetAll()
            var hotels = _hotelsRepo.GetAll();
            if (hotels != null)
                return hotels.ToList();
            // if no object return custom Exception
            throw new Exception("hotels are empty");
        }
        // The ViewSingularData(int key) takes key as parameter and returns matched hotel object
        public Hotel ViewSingularData(int key)
        {
            //  fecthing hotel object
            var hotel = _hotelsRepo.Get(key);
            if (hotel != null)
                return hotel;
            // if no object return custom Exception
            throw new Exception("no hotel with that id present");
        }
    }
}
