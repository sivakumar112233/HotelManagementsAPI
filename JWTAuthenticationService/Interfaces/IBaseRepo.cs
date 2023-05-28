namespace JWTAuthenticationServices.Interfaces
{
    public interface IBaseRepo<K,T>
    {
        // The Add(T item) takes item as parameter and adds 
        T Add(T item);
        // The Get(k Key) takes key as parameter returns matched object
        T Get(K key);
    }
}
