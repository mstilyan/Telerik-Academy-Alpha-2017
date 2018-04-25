namespace FurnitureManufacturer.Interfaces.Repository
{
    public interface IRepository<T>
    {
        bool Commit(T obj);
        bool Delete(T obj);
        T Return(string key);
    }
}