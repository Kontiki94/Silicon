using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models.Sections;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        if (viewModel.ChangePass is not null)
        {
            if (viewModel.ChangePass.ConfirmPassword != null && viewModel.ChangePass.Password != null && viewModel.ChangePass.NewPassword != null)
            {

                var result = _userService.UpdateCredentials(
                    new AccountSecurityModel()
                    {
                        Password = viewModel.ChangePass.Password,
                        NewPassword = viewModel.ChangePass.NewPassword,
                        ConfirmPassword = viewModel.ChangePass.ConfirmPassword
                    });

                if (result.Result.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    return RedirectToAction("Details", "Account");
                }
            }
        }
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Delete(AccountSecurityViewModel viewModel)
    {
        if (viewModel.Delete is not null)
        {
            if (viewModel.Delete.DeleteAccount == true)
            {
                var result = _userService.DeleteUser();
                if (result.Result.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    return RedirectToAction("SignUp", "Auth");
                }
            }
        }
        return View("Security", viewModel);
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
