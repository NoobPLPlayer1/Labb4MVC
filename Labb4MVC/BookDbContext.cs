using Labb4MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4MVC
{
    public class BookDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<LendPeriod> LendPeriods { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbcob)
        {
            dbcob.UseSqlServer(@"data Source=.\SQLEXPRESS;initial catalog=BooksDb; integrated security=SSPI");
            base.OnConfiguring(dbcob);
        }
    }
}
