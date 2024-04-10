using Cloud_Aissgnment_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_Aissgnment_1.Controllers
{
    public class UserController : Controller
    {

        public userTable usrtbl = new userTable();

        [HttpPost]
        public ActionResult ContactUs(userTable Users)
        {

            //Connected to about Page 
            var result = usrtbl.insertUser(Users);
            return RedirectToAction("About", "Home");
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            //Connected to ContactUs Page 
            return View(usrtbl);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
