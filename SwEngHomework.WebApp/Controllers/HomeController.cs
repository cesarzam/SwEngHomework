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

            DateTime giveMeTheTime = DateTime.Now;

            ViewBag.TimeNow = giveMeTheTime.ToString("yyyy-MM-ddTHH:mm:ssZ");

            //ViewBag.SecondsNow = giveMeTheTime.Second;
            //ViewBag.Even = giveMeTheTime.Minute % 2;

            if (giveMeTheTime.Second <= 30)
            {
                if (giveMeTheTime.Minute % 2 == 0)
                {
                    ViewBag.EvenLink = true;
                }
                else
                {
                    ViewBag.EvenLink = false;

                }
            }
            else
            {
                ViewBag.EvenLink = false;
            }

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