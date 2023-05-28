namespace HotelService.Interfaces
{
    public interface IRoomsService<T,K>
    {
        //The  AddingData method takes T item as parameter and adds the object and returns it
        T AddingData(T item);
        // The UpdatingData method takes T Item as Parameter and updates the object and returns it
        T UpdatingData(T item);
        //The DeletingData takes K key as parameter and Deletes the object based on the key
        T DeletingData(K key);
        //ViewingData method returns whole data as ICollection type
        ICollection<T> ViewingData();
        //The ViewSingularData method takes K key as parameter and returns particular iobject that matches the key
        T ViewSingularData(K key);



    }
}
