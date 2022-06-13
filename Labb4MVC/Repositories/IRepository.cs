namespace Labb4MVC
{
    public interface IRepository<T>
    {
        bool GetAll(out IQueryable<T> item);
        bool Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate, out IQueryable<T> item);
        bool GetSingle(System.Linq.Expressions.Expression<Func<T, bool>> predicate, out T item);
        bool Add(T item);
        bool Update(T item);
        bool Remove(T item);
    }
}
