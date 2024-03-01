using Infrastructure.Factories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels;
using Silicon_AspNetMVC.ViewModels.Account;
using Silicon_AspNetMVC.ViewModels.CompositeViewModels;

namespace Silicon_AspNetMVC.Controllers;

public class AccountController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;

    [Route("/details")]
    [HttpGet]
    public IActionResult Details()
    {
        var viewModel = new AccountViewModel();
        ViewData["Title"] = "Details";
        return View(viewModel);
    }

    [Route("/details")]
    [HttpPost]
    public IActionResult Details(AccountViewModel viewmodel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewmodel);
        }

        return RedirectToAction(nameof(Details), viewmodel);
    }

    [Route("/security")]
    [HttpGet]
    public IActionResult Security()
    {
        var viewModel = new AccountSecurityViewModel();
        ViewData["Title"] = "Security";
        return View(viewModel);
    }

    [Route("/security")]
    [HttpPost]
    public IActionResult Security(AccountSecurityViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = _userService.UpdateCredentials(viewModel.Security);
            if (result.Result.StatusCode == Infrastructure.Models.StatusCode.OK)
            {
                return RedirectToAction("Details", "Account");
            }
        }
        return View(viewModel);
    }

    [Route("/security")]
    [HttpDelete]
    public IActionResult Delete()
    {
        if (ModelState.IsValid)
        {
            var result = _userService.DeleteUser();
            if(result.Result.StatusCode == Infrastructure.Models.StatusCode.OK)
            {
                return RedirectToAction("SignIn", "Auth");
            }
        }
        return View();
    }

    public IActionResult Cancel()
    {
        return RedirectToAction("Details", "Account");
    }

    [Route("/account/saved")]
    public IActionResult SavedCourses()
    {
        var viewModel = new SavedCoursesViewModel();
        return View(viewModel);
    }

}
