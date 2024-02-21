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


        public IActionResult Security()
        {
            return View();
        }

        [Route("/details")]
        [HttpPost]
        public IActionResult Details(AccountDetailsViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            return RedirectToAction("Details", "Account");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Details", "Account");
        }
    }
}
