using Microsoft.AspNetCore.Mvc;
using SwEngHomework.WebApp.Models;
using System.Diagnostics;

namespace SwEngHomework.WebApp.Controllers
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
            var viewModel = new IndexViewModel
            {
                CurrentDateTimeUtc = DateTime.UtcNow,
                CurrentMinute = DateTime.UtcNow.Minute,
                IsWithin30Seconds = false // Set to false initially
            };

            return View(viewModel);
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