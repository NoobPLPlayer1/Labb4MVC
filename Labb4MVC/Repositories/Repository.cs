using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Labb4MVC
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> set;
        protected DbContext context;

        public Repository(DbSet<T> set, DbContext context)
        {
            this.set = set;
            this.context = context;
        }

        public bool Add(T item)
        {
            try
            {
                set.Add(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Get(Expression<Func<T, bool>> predicate, out IQueryable<T> item)
        {
            try
            {
                item = set.Where(predicate);
                return true;
            }
            catch
            {
                item = default;
                return false;
            }
        }

        public bool GetAll(out IQueryable<T> item)
        {
            item = set;
            return true;
        }

        public bool GetSingle(Expression<Func<T, bool>> predicate, out T item)
        {
            Get(predicate, out var items);
            var result = items.FirstOrDefault();
            if (result is null)
            {
                item = null;
                return false;
            }
            item = result;
            return true;
        }

        public bool Remove(T item)
        {
            try
            {
                context.ChangeTracker.Clear();
                set.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(T item)
        {
            try
            {
                context.ChangeTracker.Clear();
                set.Update(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
