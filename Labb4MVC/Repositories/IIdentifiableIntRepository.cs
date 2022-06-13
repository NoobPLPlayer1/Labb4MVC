namespace Labb4MVC
{
    public interface IIdentifiableIntRepository<T> : IRepository<T>
    {
        public bool GetByID(int id, out T item);
    }
}
