using Labb4MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;

namespace Labb4MVC.Controllers
{
    public partial class HomeController
    {
        public IActionResult Customers()
        {
            bookDb.SaveChanges();
            return View(bookDb.Customers);
        }

        public IActionResult CreateCustomer()
        {
            return View(new Customer());
        }

        public IActionResult SubmitCustomer(Customer customer)
        {
            bookDb.Add(customer);
            bookDb.SaveChanges();
            return Redirect("Customers");
        }
        public IActionResult DeleteCustomer(Customer customer)
        {
            bookDb.Remove(customer);
            bookDb.SaveChanges();
            return Redirect("../Customers");
        }

        public IActionResult EditCustomer(int id)
        {
            var customer = bookDb.Customers.Where(c => c.ID == id).FirstOrDefault();
            if (customer is null)
                return Redirect("Customers");
            return View(customer);
        }

        public IActionResult DetailCustomer(int id)
        {
            var customer = bookDb.Customers.Where(c => c.ID == id).Include(i => i.Lending).ThenInclude(i => i.Book).ThenInclude(i => i.BookType).FirstOrDefault();
            if (customer is null)
                return Redirect("Customers");
            return View(customer);
        }

        public IActionResult SubmitEditCustomer(Customer customer)
        {
            bookDb.Update(customer);
            bookDb.SaveChanges();
            return Redirect("Customers");
        }

        public IActionResult DummyCustomerLogin(Customer customer)
        {
            HttpContext.Session.SetString("login", customer.ID.ToString());
            return Redirect("../Customers");
        }
    }
}
