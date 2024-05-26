using Cloud_Aissgnment_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_Aissgnment_1.Controllers
{
    public class TransactionController : Controller
    {
        TransactionTable t = new TransactionTable();
        [HttpPost]
        public ActionResult Buy(TransactionTable t2)
        {
            t.buyProduct(t2);
            TempData["productID"] = null;
            return RedirectToAction("MyWorkPage", "Home");
        }
        [HttpPost]
        public ActionResult ClearCart()
        {
            TempData["productID"] = null;
            return RedirectToAction("Cart", "Home");
        }
    }
}
