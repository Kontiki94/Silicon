using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignInIndex()
        {
            return View();
        }
    }
}
