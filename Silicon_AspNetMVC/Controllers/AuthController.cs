using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
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
