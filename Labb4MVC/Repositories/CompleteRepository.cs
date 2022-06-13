using Labb4MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Labb4MVC.Repositories
{
    public interface ICompleteRepository : IIdentifiableIntRepository<Book>, IIdentifiableIntRepository<LendPeriod>, IIdentifiableIntRepository<Customer>, IRepository<BookType>
    {
        public bool GetByISBN(string isbn, out BookType type);
    }

    public class CompleteRepository : ICompleteRepository
    {
        IIdentifiableIntRepository<Book> books;
        IIdentifiableIntRepository<LendPeriod> lendPeriods;
        IIdentifiableIntRepository<Customer> customers;
        IRepository<BookType> bookTypes;

        public CompleteRepository(BookDbContext bookDbContext)
        {
            books = new IdentifiableIntRepository<Book>(bookDbContext.Books, bookDbContext);
            lendPeriods = new IdentifiableIntRepository<LendPeriod>(bookDbContext.LendPeriods, bookDbContext);
            customers = new IdentifiableIntRepository<Customer>(bookDbContext.Customers, bookDbContext);
            bookTypes = new Repository<BookType>(bookDbContext.BookTypes, bookDbContext);
        }

        public bool Add(Book item) => books.Add(item);

        public bool Add(LendPeriod item) => lendPeriods.Add(item);

        public bool Add(Customer item) => customers.Add(item);

        public bool Add(BookType item) => bookTypes.Add(item);

        public bool Get(Expression<Func<Book, bool>> predicate, out IQueryable<Book> item)
        {
            return books.Get(predicate, out item);
        }

        public bool Get(Expression<Func<LendPeriod, bool>> predicate, out IQueryable<LendPeriod> item)
        {
            return lendPeriods.Get(predicate, out item);
        }

        public bool Get(Expression<Func<Customer, bool>> predicate, out IQueryable<Customer> item)
        {
            return customers.Get(predicate, out item);
        }

        public bool Get(Expression<Func<BookType, bool>> predicate, out IQueryable<BookType> item)
        {
            return bookTypes.Get(predicate, out item);
        }

        public bool GetAll(out IQueryable<Book> item) => books.GetAll(out item);

        public bool GetAll(out IQueryable<LendPeriod> item) => lendPeriods.GetAll(out item);

        public bool GetAll(out IQueryable<Customer> item) => customers.GetAll(out item);

        public bool GetAll(out IQueryable<BookType> item) => bookTypes.GetAll(out item);

        public bool GetByID(int id, out Book item) => books.GetByID(id, out item);

        public bool GetByID(int id, out LendPeriod item) => lendPeriods.GetByID(id, out item);

        public bool GetByID(int id, out Customer item) => customers.GetByID(id, out item);

        public bool GetByISBN(string isbn, out BookType type)
        {
            if (GetAll(out IQueryable<BookType> types))
            {
                var res = types.Where(t => t.ISBN == isbn).FirstOrDefault();
                if(res is not null)
                {
                    type = res;
                    return true;
                }
            }
            type = default;
            return false;
        }

        public bool GetSingle(Expression<Func<Book, bool>> predicate, out Book item)
        {
            return books.GetSingle(predicate, out item);
        }

        public bool GetSingle(Expression<Func<LendPeriod, bool>> predicate, out LendPeriod item)
        {
            return lendPeriods.GetSingle(predicate, out item);
        }

        public bool GetSingle(Expression<Func<Customer, bool>> predicate, out Customer item)
        {
            return customers.GetSingle(predicate, out item);
        }

        public bool GetSingle(Expression<Func<BookType, bool>> predicate, out BookType item)
        {
            return bookTypes.GetSingle(predicate, out item);
        }

        public bool Remove(Book item) => books.Remove(item);

        public bool Remove(LendPeriod item) => lendPeriods.Remove(item);

        public bool Remove(Customer item) => customers.Remove(item);

        public bool Remove(BookType item) => bookTypes.Remove(item);

        public bool Update(Book item) => books.Update(item);

        public bool Update(LendPeriod item) => lendPeriods.Update(item);

        public bool Update(Customer item) => customers.Update(item);

        public bool Update(BookType item) => bookTypes.Update(item);
    }
}
