using Cloud_Aissgnment_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cloud_Aissgnment_1.Controllers
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

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }



        public IActionResult MyWorkPage()
        {
            List<productTable> products = productTable.ReturnProducts();
            ViewData["products"] = products;
            //Duplicate
            return View(products);
        }

        public IActionResult LoginSignup()
        {
            return View();
        }

        public IActionResult ErrorViewModel() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
