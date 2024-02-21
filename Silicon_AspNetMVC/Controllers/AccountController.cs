using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    public class AccountController : Controller
    {
        [Route("/details")]
        [HttpGet]
        public IActionResult Details()
        {
            var viewModel = new AccountDetailsViewModel();
            ViewData["Title"] = "Details";
            return View(viewModel);
        }

        [Route("/details")]
        [HttpPost]
        public IActionResult Details(AccountDetailsViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            return RedirectToAction(nameof(Details), viewmodel);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Details", "Account");
        }

        [Route("/security")]
        public IActionResult Security()
        {
            return View();
        }
    }
}
