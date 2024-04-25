
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
                ViewData["userID"] = userId;
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

        [HttpGet]
        public Dictionary<string,string> AccountDetails()
        {
            Dictionary<string, string> account = new Dictionary<string, string>();
            account.Add("name", usrtbl.UserName);
            account.Add("password", usrtbl.Password);
            account.Add("email", usrtbl.Email);
            return account;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
