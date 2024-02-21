using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    public class AuthController : Controller
    {

        [Route("/signin")]
        public IActionResult SignIn()
        {
            var viewModel = new SignInViewModel();
            ViewData["Title"] = "Sign In";
            return View(viewModel);
        }

        [Route("/signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();
            ViewData["Title"] = "Sign Up";
            return View(viewModel);
        }

        [Route("/signup")]
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel viewModel)
        {
            ViewData["Title"] = "Sign Up";
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return RedirectToAction("Details", "Account");
        }

        public new IActionResult SignOut()
        {
            return View();
        }
    }
}
