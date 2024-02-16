using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
