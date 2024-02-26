using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Details(AccountViewModel viewmodel)
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
