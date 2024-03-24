using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Home;

namespace Silicon_AspNetMVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound()
        {
            var viewModel = new PageNotFoundViewModel();
            return View(viewModel);
        }

        [Route("/denied")]
        public IActionResult AccessDenied(int statusCode) => View();
        
    }
}
