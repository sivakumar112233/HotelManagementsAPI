namespace BookingService.Interfaces
{
    public interface IBookingService<T,K>
    {
        // T CancelRReservation(K key) method takes key as parameter and deletes the object
        // and returns it
        T CancelReservation(K key);
        // T BookReservation(T item) method takes item as parameter and adds the item and 
        // returns it
        T BookReservation(T item);

    }
}
