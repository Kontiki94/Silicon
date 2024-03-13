using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Auth;
using System;
using System.Security.Claims;

namespace Silicon_AspNetMVC.Controllers
{
    public class AuthController(UserService userService, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : Controller
    {
        private readonly UserService _userService = userService;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly UserManager<UserEntity> _manager = userManager;

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
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
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

        #region External Account | Facebook
        [HttpGet]
        public IActionResult Facebook()
        {
            var authProps = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", Url.Action("ExternalCallback"));
            return new ChallengeResult("Facebook", authProps);
        }

        public IActionResult Google()
        {
            var authProps = _signInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action("ExternalCallback"));
            return new ChallengeResult("Google", authProps);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalCallback()
        {
            var userInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (userInfo is not null)
            {
                var userEntity = new UserEntity()
                {
                    FirstName = userInfo.Principal.FindFirstValue(ClaimTypes.GivenName)!,
                    LastName = userInfo.Principal.FindFirstValue(ClaimTypes.Surname)!,
                    Email = userInfo.Principal.FindFirstValue(ClaimTypes.Email)!,
                    UserName = userInfo.Principal.FindFirstValue(ClaimTypes.Email)!,
                    IsExternalAccount = true
                };
                var user = await _manager.FindByEmailAsync(userEntity.Email);
                if (user is null)
                {
                    var result = await _manager.CreateAsync(userEntity);
                    if (result.Succeeded)
                    {
                        user = await _manager.FindByEmailAsync(userEntity.Email);
                    }
                }
                if (user is not null)
                {
                    if (user.FirstName != userEntity.FirstName || user.LastName != userEntity.LastName || user.Email != userEntity.Email)
                    {
                        user.FirstName = userEntity.FirstName;
                        user.LastName = userEntity.LastName;
                        user.Email = userEntity.Email;

                        await _manager.UpdateAsync(user);
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    if (HttpContext.User is not null)
                    {
                        return RedirectToAction("Details", "Account");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
    #endregion
}
