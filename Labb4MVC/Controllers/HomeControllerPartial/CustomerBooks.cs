using Labb4MVC.Models;
using Labb4MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb4MVC.Controllers
{
    public partial class HomeController
    {

        public IActionResult CustomerBooks()
        {
            string? str = HttpContext.Session.GetString("login");
            if (str is null || !int.TryParse(str, out var id))
                return Redirect("Customers");
            repository.GetAll(out IQueryable<Book> books);
            CustomerBooks res = new()
            {
                Customer = id,
                Books = books.Include(i => i.BookType).Include(i => i.LentTo).ThenInclude(c => c.Customer).AsEnumerable().Where(b => b.LentTo.Any(lp => lp.Customer.ID == id && (lp.HasBook || lp.End >= DateTime.Now))),
            };
            return View(res);
        }

        public IActionResult TakeBook(int id)
        {
            repository.GetAll( out IQueryable<LendPeriod> periods);
            var period = periods.Where(lp => lp.ID == id).FirstOrDefault(); 
            if(period is not null && periods.Where(lp => lp.BookID == period.BookID && !lp.HasBook).Any(lp => true))
            {
                period.HasBook = true;
                repository.Update(period);
            }
            return Redirect("../CustomerBooks");
        }
        public IActionResult ReturnBook(int id)
        {
            if(repository.GetByID(id, out LendPeriod period))
            {
                period.HasBook = false;
                repository.Update(period);
            }
            return Redirect("../CustomerBooks");
        }
    }
}
