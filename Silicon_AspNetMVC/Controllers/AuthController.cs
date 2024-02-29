using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Auth;
using Silicon_AspNetMVC.ViewModels.Home;

namespace Silicon_AspNetMVC.Controllers
{
    public class AuthController(UserService userService) : Controller
    {

        private readonly UserService _userService = userService;

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
        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {
            ViewData["Title"] = "Sign In";

            if (ModelState.IsValid)
            {
                var result = await _userService.SignInUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    return RedirectToAction("Details", "Account");
                }
            }

            viewModel.ErrorMessage = "Invalid e-mail or password";
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
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            ViewData["Title"] = "Sign Up";

            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    return RedirectToAction("SignIn", "Auth");
            }

            return View(viewModel);
        }



        public new IActionResult SignOut()
        {
            var viewModel = new HomeIndexViewModel();
            ViewData["Title"] = "Silicon";
            return View(viewModel);
        }
    }
}
