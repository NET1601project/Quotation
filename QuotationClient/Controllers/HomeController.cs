using Microsoft.AspNetCore.Mvc;
using QuotationClient.Models;
using System.Diagnostics;

namespace QuotationClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult indexx()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult listing()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult register()
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
