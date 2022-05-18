using Labb4MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb4MVC.Controllers
{
    public partial class HomeController
    {

        public IActionResult Books()
        {
            bookDb.SaveChanges();
            return View(bookDb.Books.Include(i => i.BookType).Include(i => i.LentTo).ThenInclude(c => c.Customer));
        }

        public IActionResult CreateBookOfType(string isbn)
        {
            var bookType = bookDb.BookTypes.Where(c => c.ISBN == isbn).FirstOrDefault();
            var book = new Book();
            book.BookType = bookType;
            book.Status = "New";
            bookDb.Books.Add(book);
            bookDb.SaveChanges();
            return Redirect("BookTypes");
        }

        public IActionResult DeleteBook(int id)
        {
            var myBook = (from book in bookDb.Books where book.ID == id select book).FirstOrDefault();
            if (myBook is null)
                return Redirect("../Books");
            bookDb.Books.Remove(myBook);
            bookDb.SaveChanges();
            return Redirect("../Books");
        }

        public IActionResult LendBook(int id)
        {
            var myBook = (from book in bookDb.Books where book.ID == id select book).Include(b => b.LentTo).FirstOrDefault();
            if (myBook is null)
                return Redirect("../Books");

            string? str = HttpContext.Session.GetString("login");
            if (str is null || !int.TryParse(str, out id))
                return Redirect("../Books");
            var myCustomer = (from customer in bookDb.Customers where customer.ID == id select customer).FirstOrDefault();
            if (myCustomer is null)
                return Redirect("../Books");

            LendPeriod lendPeriod = new();
            lendPeriod.Book = myBook;
            lendPeriod.Customer = myCustomer;

            return View(lendPeriod);
        }

        public IActionResult SubmitLendBook(LendPeriod lendPeriod, int customer, int book)
        {
            var myCustomer = (from c in bookDb.Customers where c.ID == customer select c).FirstOrDefault();
            var myBook = (from b in bookDb.Books where b.ID == book select b).Include(b => b.LentTo).FirstOrDefault();
            lendPeriod.Customer = myCustomer;
            lendPeriod.Book = myBook;
            bookDb.Add(lendPeriod);
            bookDb.SaveChanges();
            return Redirect("Books");
        }

        public IActionResult LendingPeriods(int id)
        {
            var myBook = (from book in bookDb.Books where book.ID == id select book).FirstOrDefault();
            if (myBook is null)
                return Redirect("../Books");
            bookDb.Books.Remove(myBook);
            bookDb.SaveChanges();
            return Redirect("../Books");
        }
    }
}
