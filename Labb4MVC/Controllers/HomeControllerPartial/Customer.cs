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
            repository.GetAll(out IQueryable<Customer> customers);
            return View(customers);
        }

        public IActionResult CreateCustomer()
        {
            return View(new Customer());
        }

        public IActionResult SubmitCustomer(Customer customer)
        {
            repository.Add(customer);
            return Redirect("Customers");
        }
        public IActionResult DeleteCustomer(Customer customer)
        {
            repository.Remove(customer);
            return Redirect("../Customers");
        }

        public IActionResult EditCustomer(int id)
        {
            if (!repository.GetByID(id, out Customer customer))
                return Redirect("Customers");
            return View(customer);
        }

        public IActionResult FinishEditCustomer(Customer customer)
        {
            repository.Update(customer);
            return Redirect("Customers");
        }

        public IActionResult DetailCustomer(int id)
        {
            repository.GetAll(out IQueryable<Customer> customers);
            var customer = customers.Where(c => c.ID == id).Include(i => i.Lending).ThenInclude(i => i.Book).ThenInclude(i => i.BookType).FirstOrDefault();
            if (customer is null)
                return Redirect("Customers");
            return View(customer);
        }

        public IActionResult SubmitEditCustomer(Customer customer)
        {
            repository.Update(customer);
            return Redirect("Customers");
        }

        public IActionResult DummyCustomerLogin(Customer customer)
        {
            HttpContext.Session.SetString("login", customer.ID.ToString());
            return Redirect("../Customers");
        }
    }
}
