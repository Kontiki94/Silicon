using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Account;
using Silicon_AspNetMVC.ViewModels.CompositeViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    public class AccountController : Controller
    {
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
        public IActionResult Details(AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Navigation = new NavigationViewModel("Details");
                return View(viewModel);
            }

            return RedirectToAction(nameof(Details), viewModel);
        }

        [Route("/security")]
        [HttpGet]
        public IActionResult Security()
        {
            var viewModel = new AccountViewModel();
            ViewData["Title"] = "Security";
            return View(viewModel);
        }

        [Route("/security")]
        [HttpPost]
        public IActionResult Security(AccountViewModel viewModel)
        {
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

        [Route("/account/saved")]
        public IActionResult SavedCourses()
        {
            var viewModel = new SavedCoursesViewModel();
            return View(viewModel);
        }
    }
}
