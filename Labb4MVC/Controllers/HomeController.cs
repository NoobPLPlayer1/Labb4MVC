using Labb4MVC.Models;
using Labb4MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Labb4MVC.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompleteRepository repository;

        public HomeController(ILogger<HomeController> logger, ICompleteRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}