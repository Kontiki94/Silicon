using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Account;
using Silicon_AspNetMVC.ViewModels.CompositeViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        [Authorize]
        [Route("/details")]
        public IActionResult Details()
        {

            var viewModel = new AccountViewModel();
            viewModel.Navigation = new NavigationViewModel("Details");
            ViewData["Title"] = "Details";
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [Route("/details")]
        public IActionResult Details(AccountViewModel viewModel)
        {
            viewModel.Navigation = new NavigationViewModel("Details");
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return RedirectToAction(nameof(Details), viewModel);
        }

        [HttpGet]
        [Authorize]
        [Route("/security")]
        public IActionResult Security()
        {
            var viewModel = new AccountViewModel();
            viewModel.Navigation = new NavigationViewModel("Security");
            ViewData["Title"] = "Security";
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [Route("/security")]
        public IActionResult Security(AccountViewModel viewModel)
        {
            viewModel.Navigation = new NavigationViewModel("Security");
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return RedirectToAction("Details", "Account");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Details", "Account");
        }

        [Authorize]
        [Route("/saved")]
        public IActionResult SavedCourses()
        {
            var viewModel = new SavedCoursesViewModel();
            return View(viewModel);
        }
    }
}
