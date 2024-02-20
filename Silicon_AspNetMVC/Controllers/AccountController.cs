using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels;

namespace Silicon_AspNetMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Profile";
            return View();
        }

        [Route("/details")]
        public IActionResult Details()
        {
            var viewModel = new AccountDetailsViewModel();
            ViewData["Title"] = "Details";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveDetails()
        {
            return RedirectToAction("Details", "Account");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Details", "Account");
        }
    }
}
