using Cloud_Aissgnment_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Cloud_Aissgnment_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeController> _logger;


        // provate readonly IHttpContextAccessor _httpContextAccessor
        // int? userID = _httpCOntextAccessor.HttpContext.Seesion.GetInt32("UserID");
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
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

        public IActionResult Cart()
        {
            List<productTable> products = productTable.ReturnProducts();
            ViewData["products"] = products;
            return View();
        }

        public IActionResult Account()
        {
            if (null != TempData["userID"])
            {

                int userID = int.Parse(TempData["userID"].ToString());
                TempData["UserID"] = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
                //TempData["userID"] = userID;

                userTable usrtbl = new userTable();
                TransactionTable t = new TransactionTable();

                List<string> details = usrtbl.userDetails(userID);

                TempData["username"] = details[0];
                TempData["email"] = details[1];
                TempData["password"] = details[2];
                TempData["userID"] = userID;

                List<productTable> orders = t.getOrders(userID);
                List<productTable> products = t.getOwnedOrders(userID);
                TempData["orders"] = orders;
                TempData["products"] = products;
            }

            return View();
        }
        public IActionResult MyWorkPage()
        {
            List<productTable> products = productTable.ReturnProducts();
            ViewData["products"] = products;
            //Duplicate
            return View();
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
