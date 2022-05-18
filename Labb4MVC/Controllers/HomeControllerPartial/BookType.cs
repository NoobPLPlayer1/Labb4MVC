using Labb4MVC.Models;
using Microsoft.AspNetCore.Mvc;
namespace Labb4MVC.Controllers
{
    public partial class HomeController
    {
        public IActionResult CreateBookType()
        {
            return View(new BookType());
        }
        public IActionResult EditBookType(string value)
        {
            var type = bookDb.BookTypes.Where(c => c.ISBN == value).FirstOrDefault();
            if (type is null)
                return Redirect("BookTypes");
            return View(type);
        }

        public IActionResult FinishEditCustomer(Customer customer)
        {
            bookDb.Update(customer);
            bookDb.SaveChanges();
            return Redirect("Customers");
        }

        public IActionResult SubmitBookType(BookType type)
        {
            bookDb.BookTypes.Add(type);
            bookDb.SaveChanges();
            return Redirect("BookTypes");
        }
        public IActionResult DeleteBookType(BookType type)
        {
            bookDb.Remove(type);
            bookDb.SaveChanges();
            return Redirect("../BookTypes");
        }

        public IActionResult BookTypes()
        {
            bookDb.SaveChanges();
            return View(bookDb.BookTypes);
        }
    }
}
