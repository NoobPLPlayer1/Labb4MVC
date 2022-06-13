using Labb4MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb4MVC.Controllers
{
    public partial class HomeController
    {



        public IActionResult Books()
        {
            if(repository.GetAll(out IQueryable<Book> books))
                return View(books.Include(i => i.BookType).Include(i => i.LentTo).ThenInclude(c => c.Customer));
            return View();
        }

        public IActionResult CreateBookOfType(string isbn)
        {
            repository.GetByISBN(isbn, out var bookType);
            var book = new Book();
            book.BookType = bookType;
            book.Status = "New";
            repository.Add(book);
            return Redirect("BookTypes");
        }

        public IActionResult DeleteBook(int id)
        {
            repository.GetByID(id, out Book myBook);
            if (myBook is null)
                return Redirect("../Books");
            repository.Remove(myBook);
            return Redirect("../Books");
        }

        public IActionResult LendBook(int id)
        {
            repository.Get(b => b.ID == id, out IQueryable<Book> books);
            var myBook = books.Include(b => b.LentTo).FirstOrDefault();
            if (myBook is null)
                return Redirect("../Books");

            string? str = HttpContext.Session.GetString("login");
            if (str is null || !int.TryParse(str, out id))
                return Redirect("../Books");
            repository.GetByID(id, out Customer myCustomer);
            if (myCustomer is null)
                return Redirect("../Books");

            LendPeriod lendPeriod = new();
            lendPeriod.Book = myBook;
            lendPeriod.Customer = myCustomer;

            return View(lendPeriod);
        }

        public IActionResult SubmitLendBook(LendPeriod lendPeriod, int customer, int book)
        {
            repository.GetByID(customer, out Customer myCustomer);
            repository.GetByID(book, out Book myBook);
            lendPeriod.Customer = myCustomer;
            lendPeriod.Book = myBook;
            lendPeriod.BookID = myBook.ID;
            repository.Add(lendPeriod);
            return Redirect("Books");
        }

        public IActionResult LendingPeriods(int id)
        {
            repository.GetAll(out IQueryable<LendPeriod> lendingPeriod);
            return View(lendingPeriod.Where(l => l.Customer.ID == id));
        }

        public IActionResult DeleteLendingPeriod(int id)
        {
            repository.GetByID(id, out LendPeriod myBook);
            if (myBook is null)
                return Redirect("..");
            repository.Remove(myBook);
            return Redirect("..");
        }
    }
}
