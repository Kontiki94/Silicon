using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Profile";
            return View();
        }

        public IActionResult SignIn()
        {
            ViewData["Title"] = "Sign In";
            return View();
        }
        
        public IActionResult SignUp()
        {
            ViewData["Title"] = "Sign Up";
            return View();
        }
       
    }
}
