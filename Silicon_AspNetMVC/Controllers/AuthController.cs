using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Auth;
using System.Security.Claims;

namespace Silicon_AspNetMVC.Controllers
{
    public class AuthController(UserService userService, SignInManager<UserEntity> signInManager) : Controller
    {

        private readonly UserService _userService = userService;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;

        [HttpGet]
        [Route("/signin")]
        public IActionResult SignIn(string returnUrl)
        {
            var viewModel = new SignInViewModel();
            ViewData["Title"] = "Sign In";
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Details", "Account");
            }
            ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");
            return View(viewModel);
        }

        [HttpPost]
        [Route("/signin")]
        public async Task<IActionResult> SignIn(SignInViewModel viewModel, string returnUrl)
        {
            ViewData["Title"] = "Sign In";

            if (ModelState.IsValid)
            {
                var result = await _userService.SignInUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
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
                {
                    return RedirectToAction("SignIn", "Auth");
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        [Route("/signout")]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
