
using Cloud_Aissgnment_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace Cloud_Aissgnment_1.Controllers
{
    public class UserController : Controller
    {

        public userTable usrtbl = new userTable();
        public LoginModel lm = new LoginModel();

        [HttpPost]
        public ActionResult SignUp(userTable Users)
        {
            //Connected to about Page 
            var result = usrtbl.insertUser(Users);
            return RedirectToAction("About", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginModel l)
        {

            int UserID = lm.selectUser(l);
            if (UserID != -1)
            {
                // Redirect After User Found
                TempData["userID"] = UserID;
                HttpContext.Session.SetInt32("UserID", UserID);
                return RedirectToAction("Account", "Home");
            }
            else
            {
                // User not found
                return Content("User Not Found", "text / html");
            }
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Account()
        {
            if (TempData["userID"] != null)
            {

            }
            return RedirectToAction("Account", "Home");

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
