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
        public IActionResult EditBookType(string isbn)
        {
            if (!repository.GetByISBN(isbn, out var type))
                return Redirect("BookTypes");
            return View(type);
        }

        public IActionResult FinishEditBookType(BookType type)
        {
            repository.Update(type);
            return Redirect("BookTypes");
        }

        public IActionResult SubmitBookType(BookType type)
        {
            repository.Add(type);
            return Redirect("BookTypes");
        }
        public IActionResult DeleteBookType(BookType type)
        {
            repository.GetByISBN(type.ISBN, out var bookType);
            repository.Remove(bookType);
            return Redirect("BookTypes");
        }

        public IActionResult BookTypes()
        {
            repository.GetAll(out IQueryable<BookType> types);
            return View(types);
        }
    }
}
