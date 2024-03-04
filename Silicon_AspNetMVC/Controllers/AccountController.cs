using Infrastructure.Models.Sections;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Silicon_AspNetMVC.ViewModels.Account;
using Silicon_AspNetMVC.ViewModels.CompositeViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    [Authorize]
    public class AccountController(UserService userService) : Controller
    {
        private readonly UserService _userService = userService;

        [HttpGet]
        [Route("/details")]
        public IActionResult Details()
        {
            var viewModel = new AccountViewModel();
            ViewData["Title"] = "Details";
            return View(viewModel);
        }

        [HttpPost]
        [Route("/details")]
        public IActionResult Details(AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Navigation = new NavigationViewModel("Details");
                return View(viewModel);
            }
            return RedirectToAction(nameof(Details), viewModel);
        }


        [HttpGet]
        [Route("/security")]
        public IActionResult Security()
        {
            var viewModel = new AccountViewModel();
            viewModel.Navigation = new NavigationViewModel("Security");
            ViewData["Title"] = "Security";
            return View(viewModel);
        }

        [HttpPost]
        [Route("/security")]
        public IActionResult Security(AccountViewModel viewModel)
        {
            viewModel.Navigation = new NavigationViewModel("Security");
            if (viewModel.ChangePass is not null)
            {
                if (viewModel.ChangePass.ConfirmPassword != null && viewModel.ChangePass.Password != null && viewModel.ChangePass.NewPassword != null && viewModel.ChangePass.NewPassword == viewModel.ChangePass.ConfirmPassword)
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
            return View("Security", viewModel);
        }

        [HttpPost]
        public IActionResult Delete(AccountViewModel viewModel)
        {
            viewModel.Navigation = new NavigationViewModel("Security");
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

        [Route("/saved")]
        public IActionResult SavedCourses()
        {
            var viewModel = new SavedCoursesViewModel();
            return View(viewModel);
        }
    }
}

