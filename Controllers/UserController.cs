
using Cloud_Aissgnment_1.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;


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

            int userId = lm.selectUser(l);
            if (userId != -1)
            {
                // User found, proceed with login logic (e.g., set authentication cookie)
                // For demonstration, redirecting to a dummy page
                TempData["userID"] = userId;
                return RedirectToAction("Index", "Home", new { userId = userId });
            }
            else
            {
                // User not found, handle accordingly (e.g., show error message)
                return Content("Zain Ul Hassan", "text / html");
            }
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Account()
        {
            if (TempData["userID"] != null) {

                List<string> details =usrtbl.userDetails( int.Parse( TempData["userID"].ToString()));
                TempData["username"] = details[0];
                TempData["email"] = details[1];
                TempData["password"] = details[2];
            }
            return RedirectToAction("Account", "Home");

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
