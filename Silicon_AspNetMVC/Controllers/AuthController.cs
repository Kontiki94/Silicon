using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_AspNetMVC.Services;
using Silicon_AspNetMVC.ViewModels.Auth;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace Silicon_AspNetMVC.Controllers;

public class AuthController(UserService userService, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, AuthServices authServices) : Controller
{
    private readonly UserService _userService = userService;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _manager = userManager;
    private readonly AuthServices _authServices = authServices;


    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        try
        {
            var viewModel = new SignInViewModel();
            ViewData["Title"] = "Sign In";
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");
            return View(viewModel);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return View("Home", "Index");
        }
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel, string returnUrl)
    {
        try
        {
            ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");
            ViewData["Title"] = "Sign In";
            if (ModelState.IsValid)
            {
                var result = await _userService.SignInUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    var token = await _authServices.GetAuthTokenAsync(viewModel);
                    if (token != null)
                    {
                        var cookieOptions = new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            Expires = DateTime.Now.AddDays(1)
                        };

                        Response.Cookies.Append("AccessToken", token, cookieOptions);

                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
            }
            viewModel.ErrorMessage = "Invalid e-mail or password";
            return View(viewModel);
        }
        catch (Exception ex)
        {
            viewModel.ErrorMessage = $"Server is down {ex.Message}";
            return RedirectToAction("Index", "Home");
        }
    }

    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        try
        {
            var viewModel = new SignUpViewModel();
            ViewData["Title"] = "Sign Up";
            return View(viewModel);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return View("Home", "Index");
        }
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        try
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
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return View(viewModel);
        }
    }

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        try
        {
            Response.Cookies.Delete("AccessToken");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return NoContent();
        }
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
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        return RedirectToAction("Index", "Home");
    }
}
#endregion
