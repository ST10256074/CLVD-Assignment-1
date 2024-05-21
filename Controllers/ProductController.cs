using Cloud_Aissgnment_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_Aissgnment_1.Controllers
{
    public class ProductController : Controller
    {
        public productTable prdtbl = new productTable();
        public IActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(productTable p)
        {
            // Receive data from the form
            var files = Request.Form.Files;
            var result = prdtbl.insertProduct(p);
            return RedirectToAction("MyWorkPage", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        public ActionResult Cart(string userID, string productID)
        {
            TempData["productID"] = productID.ToString();
            TempData["userID"] = userID.ToString();
            return RedirectToAction("Cart", "Home", productID);
        }


    }
}
