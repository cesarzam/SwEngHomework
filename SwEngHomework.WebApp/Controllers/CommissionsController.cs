using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using SwEngHomework.Commissions;




namespace SwEngHomework.WebApp.Controllers
{
    public class CommissionsController : Controller
    {
        private readonly ILogger<OtherController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICommissionCalculator _commissionCalculator;
        public CommissionsController(ILogger<OtherController> logger, ICommissionCalculator commissionCalculator, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;   
            _commissionCalculator = commissionCalculator;
            _hostingEnvironment = hostingEnvironment;
        }  
        private ICommissionCalculator commissionCalculator;

        
        public IActionResult Calculator()
        {

            string jsonFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Models", "input.json");
            string jsonInput = System.IO.File.ReadAllText(jsonFilePath);

            IDictionary<string, double> report= _commissionCalculator.CalculateCommissionsByAdvisor(jsonInput);

            return View(report);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
