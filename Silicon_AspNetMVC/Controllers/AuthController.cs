using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    public class AuthController : Controller
    {

        [Route("/signin")]
        [HttpGet]
        public IActionResult SignIn()
        {
            var viewModel = new SignInViewModel();
            ViewData["Title"] = "Sign In";
            return View(viewModel);
        }

        [Route("/signin")]
        [HttpPost]
        public IActionResult SignIn(SignInViewModel viewModel)
        {
            ViewData["Title"] = "Sign In";

            if (!ModelState.IsValid)
            {
                viewModel.ErrorMessage = "Invalid e-mail or password";
                return View(viewModel);
            }

            return RedirectToAction("SignIn", "Auth");
        }

        [Route("/signup")]
<<<<<<< HEAD
        [HttpGet]
=======
        // ! Ta bort kommentaren när det finns en view för signup med en form som har method=post.
        // ! Behövs en get och en post for signup
        //[HttpPost]
>>>>>>> 0f44a946cba5f0e4c8b0a7d8e820b2d729436f0e
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
