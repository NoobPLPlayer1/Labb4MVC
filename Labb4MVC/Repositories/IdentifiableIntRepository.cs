using Microsoft.EntityFrameworkCore;

namespace Labb4MVC
{
    public class IdentifiableIntRepository<T> : Repository<T>, IIdentifiableIntRepository<T> where T : class, IIdentifiableInt
    {
        public IdentifiableIntRepository(DbSet<T> set, DbContext context) : base(set, context)
        {
        }

        public bool GetByID(int id, out T item)
        {
            var res = set.Where(t => t.ID == id).FirstOrDefault();
            if(res == null)
            {
                item = default;
                return false;
            }
            else
            {
                item = res;
                return true;
            }
        }
    }
}
