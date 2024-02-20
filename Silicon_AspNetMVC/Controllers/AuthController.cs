using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.Controllers
{
    public class AuthController : Controller
    {

        [Route("/signin")]
        public IActionResult SignIn()
        {
            var viewModel = new SignInModel();
            ViewData["Title"] = "Sign In";
            return View(viewModel);
        }

        [Route("/signup")]
        public IActionResult SignUp()
        {
            ViewData["Title"] = "Sign Up";
            return View();
        }

        public new IActionResult SignOut()
        {
            return View();
        }
    }
}
