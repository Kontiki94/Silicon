using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    public class AccountController : Controller
    {
        //public IActionResult Index()
        //{
        //    ViewData["Title"] = "Profile";
        //    return View();
        //}

        [Route("/details")]
        [HttpGet]
        public IActionResult Details()
        {
            var viewModel = new AccountDetailsViewModel();
            ViewData["Title"] = "Details";
            return View(viewModel);
        }

<<<<<<< HEAD
        public IActionResult Security()
        {
            return View();
        }

=======
        [Route("/details")]
>>>>>>> 0f44a946cba5f0e4c8b0a7d8e820b2d729436f0e
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
