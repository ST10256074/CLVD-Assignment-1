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
            var result = prdtbl.insertProduct(p);
            return RedirectToAction("MyWorkPage", "Home");

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
