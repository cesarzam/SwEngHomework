using Microsoft.AspNetCore.Mvc;
using SwEngHomework.DescriptiveStatistics;

namespace SwEngHomework.WebApp.Controllers
{
    public class StatsController : Controller
    {
        private readonly ILogger<OtherController> _logger;
        private readonly IStatsCalculator _istatscalculator;
        public StatsController(ILogger<OtherController> logger, IStatsCalculator statsCalculator)
        {
            _logger = logger;
            _istatscalculator = statsCalculator;
        }

        public IActionResult Stats()
        {
            //string jsonInput = "5; $ 123.42; $5,401.56";
            string jsonInput = "$2,550.50; 1000; $6345.45; 7,565.65;12,568.68;$6356.56;2550.5; 500.45";

            Stats statistics = _istatscalculator.Calculate(jsonInput);

            return View(statistics);
        }
    }
}
