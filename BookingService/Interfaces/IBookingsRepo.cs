namespace BookingService.Interfaces
{
    public interface IBookingsRepo<T,K>
    {
        //The Add method takes T item as a parameter and returns T object
        T Add(T item);
        //The Delete Method takes k key as parameter based the key matches it gets delete the object 
        //and returns the deleted object
        T Delete(K key);

        //The Update method also takes the T item as parameter and returns updated object
        T Update(T item);
        // The Get method takes one parameter that is K key
        // The Get method used to get particular object based on the key
        T Get(K key);
        // GetAll method takes zero parameters 
        //GetAll method returns all objects as ICollection type
        ICollection<T> GetAll();


    }
}
